using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LastMinuteTours.Entities;
namespace LastMinuteTours.App
{
    public static class TourValidation
    {
        public static bool IsValid(this TourModel model)
        {
            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            return Validator.TryValidateObject(model, ctx, results, true);
        }
    }
}
