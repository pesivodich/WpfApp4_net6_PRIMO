using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp4_net6.Models
{
    [Table("Users")]
    public partial class User : TableHaveIdInt, ITable
    {
        public User()
        {
          
        }
        public int UserInfoId { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

       
        [StringLength(50)]
        public string Password { get; set; }

      
        [StringLength(10)]
        public string FirstSecurityString { get; set; }

        [StringLength(10)]
        public string LastSecurityString { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
        public DateTimeOffset CreatedAt { set; get; }
        public int CreatedBy { set; get; }

        [StringLength(50)]
        public string CreatedIp { set; get; }

        public DateTimeOffset? UpdatedAt { set; get; }

        public int? UpdatedBy { set; get; }

        [StringLength(50)]
        public string UpdatedIp { set; get; }

        public bool DelFlag { set; get; }

        public virtual UserInfo Information { set; get; }

      
    }
}
