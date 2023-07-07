using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Alzheimer.Models
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }


        //  update
        //[Required]
        //[DataType(DataType.Password)]
        //[Compare(nameof(NewPassword))]
        //public string ConfirmPassword { get; set; }

    }
}
