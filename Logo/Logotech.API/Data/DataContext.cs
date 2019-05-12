/* Classe permettant de faire le lien entre les modèles des données et la base de données
par l'intermédiaire du framework entity */

using Logotech.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Logotech.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){  }
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Docteur> Docteurs { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
