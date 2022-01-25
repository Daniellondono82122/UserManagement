namespace UserManagement.Domain.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual List<State> States { get; set; }
    }
}
