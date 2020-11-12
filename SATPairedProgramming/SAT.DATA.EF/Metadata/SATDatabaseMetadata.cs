using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SAT.DATA.EF
{
    [MetadataType(typeof(CoursMetaData))]
    public partial class Cours { }

    #region Cours
    public class CoursMetaData
    {
        [Required(ErrorMessage ="*Course Name Required")]
        [StringLength(50, ErrorMessage = "*50 character limit")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required(ErrorMessage ="*Course Description Required")]
        [Display(Name = "Course Description")]
        [UIHint("MultilineText")]
        public string CourseDescription { get; set; }

        [Required(ErrorMessage ="*Credit Hours Required")]
        [Display(Name = "Credit Hours")]
        [Range(0, double.MaxValue, ErrorMessage = "Invalid Value")]
        public byte CreditHours { get; set; }

        [StringLength(250, ErrorMessage = "*250 character limit")]
        [Display(Name = "Curriculum")]
        [DisplayFormat(NullDisplayText = "*Not Available")]
        [UIHint("MultilineText")]
        public string Curriculum { get; set; }

        [Display(Name = "Notes")]
        [DisplayFormat(NullDisplayText = "*Not Available")]
        [UIHint("MultilineText")]
        public string Notes { get; set; }

        [Display(Name = "Active Class")]
        public bool IsActive { get; set; }
    }
    #endregion
    #region Enrollment
    [MetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollment
    {
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return ($"{Student.FirstName} {Student.LastName}"); }
        }
    }

    public class EnrollmentMetadata
    {
        [Required(ErrorMessage = "*Student ID Required")]
        [Display(Name = "Student ID")]
        [Range(0, double.MaxValue, ErrorMessage = "Invalid Value")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "*Scheduled Class ID Required")]
        [Display(Name = "Scheduled Class ID")]
        [Range(0, double.MaxValue, ErrorMessage = "Invalid Value")]
        public int ScheduledClassId { get; set; }

        [Required(ErrorMessage = "*Enrollment Date Required")]
        [Display(Name = "Enrollment Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public System.DateTime EnrollmentDate { get; set; }

    }
    #endregion

    #region ScheduledClass
    [MetadataType(typeof(ScheduledClassMetadata))]
    public partial class ScheduledClass
    {
        [Display(Name = "Full Course Information")]
        public string FullCourseInfo
        {
            get { return ($"{Cours.CourseName} | {StartDate:d} | {Location} | ({InstructorName})"); } 
        }
    }

    public class ScheduledClassMetadata
    {

        [Required(ErrorMessage = "*Course ID Required")]
        [Display(Name = "Course ID")]
        [Range(0, double.MaxValue, ErrorMessage = "Invalid Value")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "*Start Date Required")]
        [Display(Name = "Scheduled Class Start Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public System.DateTime StartDate { get; set; }

        [Required(ErrorMessage ="*End Date Required")]
        [Display(Name ="Scheduled Class End Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public System.DateTime EndDate { get; set; }

        [Required(ErrorMessage ="*Instructor Name Required")]
        [Display(Name ="Instructor Name")]
        public string InstructorName { get; set; }

        [Required(ErrorMessage ="*Location Required")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required(ErrorMessage ="*SCSID (Scheduled Class Status ID) Required")]
        [Display(Name ="SCSID (Scheduled Class Status ID")]
        [Range(0, double.MaxValue, ErrorMessage = "Invalid Value")]
        public int SCSID { get; set; }
    }
    #endregion

    #region ScheduledClassStatus

    [MetadataType(typeof(ScheduledClassStatusMetadata))]
    public partial class ScheduledClassStatus { }

    public class ScheduledClassStatusMetadata
    {
        [Required(ErrorMessage ="*Scheduled Class Status Name Required")]
        [Display(Name ="Scheduled Class Status ID")]
        public string SCSName { get; set; }
    }
    #endregion

    #region Student

    [MetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return ($"{FirstName} {LastName}"); }
        }
    }

    public class StudentMetadata
    {
        [Required(ErrorMessage = "*First Name Required")]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage = "*20 character limit")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*Last Name Required")]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "*20 character limit")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*Major Required")]
        [StringLength(15, ErrorMessage = "*15 character limit")]
        [DisplayFormat(NullDisplayText = "*Not Available")]
        public string Major { get; set; }

        [StringLength(50, ErrorMessage = "*50 character limit")]
        [DisplayFormat(NullDisplayText = "*Not Available")]
        public string Address { get; set; }

        [StringLength(25, ErrorMessage = "*25 character limit")]
        [DisplayFormat(NullDisplayText = "*Not Available")]
        public string City { get; set; }

        [DisplayFormat(NullDisplayText = "*Not Available")]
        [StringLength(2, ErrorMessage = "*2 character limit")]
        public string State { get; set; }

        [DisplayFormat(NullDisplayText = "*Not Available")]
        [StringLength(10, ErrorMessage = "*10 character limit")]
        public string ZipCode { get; set; }

        [DisplayFormat(NullDisplayText = "*Not Available")]
        [StringLength(13, ErrorMessage = "*13 character limit")]
        [RegularExpression("phone", ErrorMessage = "*Please input a valid phone number: 123-456-6789")]
        public string Phone { get; set; }

        [StringLength(60, ErrorMessage = "*60 character limit")]
        [RegularExpression("Email", ErrorMessage = "*Please input a valid e-mail (user@email.com)")]
        public string Email { get; set; }

        [Display(Name = "Photo URL")]
        [DisplayFormat(NullDisplayText = "*Not Available")]
        [StringLength(100, ErrorMessage = "*100 character limit")]
        public string PhotoUrl { get; set; }

        [Display(Name = "Student Status ID")]
        [DisplayFormat(NullDisplayText = "*Not Available")]
        [Range(0, double.MaxValue, ErrorMessage = "Invalid Value")]
        public Nullable<int> SSID { get; set; }
    }

    #endregion
    #region StudentStatus

    [MetadataType(typeof(StudentStatusMetadata))]
    public partial class StudentStatus { }

    public class StudentStatusMetadata
    {
        [Required(ErrorMessage = "Student Status Name")]
        [StringLength(30, ErrorMessage = "*30 character limit")]
        public string SSName { get; set; }

        [StringLength(250, ErrorMessage = "*250 character limit")]
        [UIHint("MultilineText")]
        [DisplayFormat(NullDisplayText = "*Not Available")]
        public string SSDescription { get; set; }
    }
#endregion








} //end Namespace
