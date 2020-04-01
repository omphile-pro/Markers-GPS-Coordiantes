using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Markers_GPS_Coordiantes.Data
{
    public partial class UserRole
    {
        public string Displayname { get; set; }
        public int RoleId { get; set; }
        public string PositionDescription { get; set; }
        public int PositionId { get; set; }
       
        public string RoleDescription { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Please Enter Centre Number")]
        [DisplayName("User")]
        public int UsersId { get; set; }
        public int UsersRoleId { get; set; }
    }
}
