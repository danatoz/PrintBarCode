namespace PrinBarCode.DAL.DataModel
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BarCodeContext : DbContext
    {
        // Контекст настроен для использования строки подключения "BarCodeContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "PrinBarCode.DAL.DataModel.BarCodeContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "BarCodeContext" 
        // в файле конфигурации приложения.
        public BarCodeContext()
            : base("name=BarCodeContext")
        {
        }

        public DbSet<EncryptedDate> EncryptedDates { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}