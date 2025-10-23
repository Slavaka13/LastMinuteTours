using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace LastMinuteTours.Infrostructure
{
    /// <summary>
    /// Класс для упрощения работы с привязкой данных и валидацией
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Метод для создания привязки данных между свойством контрола и свойством источника данных
        /// </summary>
        public static void AddBinding<TControl, TSource>(this TControl control, 
            Expression<Func<TControl, object>> destinationProperty,
            TSource source,
            Expression<Func<TSource, object>> sourceProperty,
            ErrorProvider? errorProvider = null)
            where TControl : Control
            where TSource : class
        {
            
            var destinationPropertyName = GetPropertyName(destinationProperty); // Получаем имя свойства контрола
            var sourcePropertyName = GetPropertyName(sourceProperty); // Получаем имя свойства модели

            // Связываем свойство контрола со свойством источника данных
            control.DataBindings.Add(destinationPropertyName, source, sourcePropertyName,
                true, DataSourceUpdateMode.OnPropertyChanged);

            if (errorProvider != null)
            {
                // Обработчик потери фокуса для валидации
                control.Validating += (sender, e) =>
                {
                    ValidateControl(control, source, sourcePropertyName, errorProvider);
                };

                // Обработчик изменения текста для TextBox
                if (control is TextBox textBox)
                {
                    textBox.TextChanged += (sender, e) =>
                    {
                        ValidateControl(control, source, sourcePropertyName, errorProvider);
                    };
                }

                // Обработчик изменения значения для NumericUpDown
                if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.ValueChanged += (sender, e) =>
                    {
                        ValidateControl(control, source, sourcePropertyName, errorProvider);
                    };
                }
            }
        }

        /// <summary>
        /// Метод для извлечения имени свойства
        /// </summary>
        private static string GetPropertyName<T>(Expression<Func<T, object>> expression)
        {
            var memberExpression = expression.Body as MemberExpression; // Получаем доступ к свойству как MemberExpression

            if (memberExpression == null)
            {
                var unaryExpression = expression.Body as UnaryExpression;
                if (unaryExpression != null)
                {
                    memberExpression = unaryExpression.Operand as MemberExpression; // Извлекаем операнд унарного выражения (само свойство)
                }
            }

            if (memberExpression != null && memberExpression.Member is PropertyInfo)
            {
                return memberExpression.Member.Name; // Возвращаем имя свойства
            }

            throw new ArgumentException("Expression must be a property access", nameof(expression));
        }

        /// <summary>
        /// Метод для валидации отдельного контрола
        /// </summary>
        private static void ValidateControl<TControl, TSource>(TControl control, TSource source,
            string sourcePropertyName, ErrorProvider errorProvider)
            where TControl : Control
            where TSource : class
        {

            var context = new ValidationContext(source);
            var results = new List<ValidationResult>();

            // Валидируем весь объект, но берем ошибку только для нужного свойства
            Validator.TryValidateObject(source, context, results, true);

            var propertyError = results.FirstOrDefault(x => x.MemberNames.Contains(sourcePropertyName)); // Фильтрация ошибок для конкретного свойства

            // Отображение или скрытие ошибки
            if (propertyError != null)
            {
                errorProvider.SetError(control, propertyError.ErrorMessage);
            }
            else
            {
                errorProvider.SetError(control, string.Empty);
            }
        }

        /// <summary>
        /// Метод для проверки валидности всего объекта
        /// </summary>
        public static bool IsValid(this object obj)
        {
            // Создание контекста валидации
            var context = new ValidationContext(obj);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, context, results, true); // Возвращение результата валидации
        }
    }
}
