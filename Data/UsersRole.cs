using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class UsersRole
    {
        public int UsersRoleId { get; set; }
        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Please Select User")]
        [DisplayName("User")]
        public int UsersId { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Assign Required Role The User")]
        [DisplayName("Role")]
        public int RoleId { get; set; }
        public int CreatedByUsersId { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Users CreatedByUsers { get; set; }
        public virtual Role Role { get; set; }
        public virtual Users Users { get; set; }
    }
}
