using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodigoPenalApi.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string UserName { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    [Table("Status")]
    public class Status
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
    [Table("CriminalCode")]
    public class CriminalCode
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        public decimal Penalty { get; set; }
        [Required]
        public int PrisionTime { get; set; }
        //fk StatusId
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        //fk CreateUserId
        //fk UpdateUserId
    }
}
