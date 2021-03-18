using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataViewModel
{
    [Validator(typeof(InventoryValidator))]
    public class InventoryModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class InventoryValidator : AbstractValidator<InventoryModel>
    {
        /// <summary>  
        /// Validator rules for Product  
        /// </summary>  
        public InventoryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("The Inventory ID must be at greather than 0.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("The Inventory Name cannot be blank.")
                .Length(0, 100)
                .WithMessage("The Inventory Name cannot be more than 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("The Inventory Description must be at least 150 characters long.");

            RuleFor(x => x.Price).GreaterThan(0).WithMessage("The Inventory Price must be at greather than 0.");
        }
    }

}
