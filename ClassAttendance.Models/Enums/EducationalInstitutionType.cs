using System.ComponentModel.DataAnnotations;

namespace ClassAttendance.Models.Enums
{
    public enum EducationalInstitutionType
    {
        [Display(Name ="School")]
        School,
        Collage,
        [Display(Name = "Vocational School")]
        VocationalSchool,
        University,
        Institute
    }
}