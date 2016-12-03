using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project2.Models
{
    [Table("Missions")]
    public class Missions
    {
        [Required]
        [Key]
        public int missionID { get; set; }

        [Required]
        [Display(Name = "Mission Name")]
        public String missionName { get; set; }

        [Required]
        public String missionPresFName { get; set; }

        [Required]
        public String missionPresLName { get; set; }

        [Required]
        [Display(Name = "Mission Address")]
        public String missionAddress { get; set; }

        [Required]
        public String missionCity { get; set; }

        public String missionState { get; set; }

        [Required]
        public String missionCountry { get; set; }

        public String missionZip { get; set; }

        [Required]
        [Display(Name = "Mission Language")]
        public String language { get; set; }

        [Required]
        [Display(Name = "Mission Climate")]
        public String climate { get; set; }

        [Required]
        [Display(Name = "Dominant Religion")]
        public String dominantReligion { get; set; }

        [Display(Name = "Mission Symbol")]
        public String missionSymbol { get; set; }
    }
}