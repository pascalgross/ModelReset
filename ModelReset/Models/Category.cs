using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Catel.Data;
using Catel.Fody;
using ModelReset.Contracts;

namespace ModelReset.Models
{
    [Table("Categories")]
    [NoWeaving]
    public class Category : ModelBase, IEntityBase
    {
        public string Description { get; set; } = "initial category description";

        public virtual ICollection<Part> Parts { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}