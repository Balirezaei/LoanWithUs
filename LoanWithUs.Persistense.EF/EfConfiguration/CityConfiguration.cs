using LoanWithUs.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWithUs.Persistense.EF.EfConfiguration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(m => m.Id);
            builder.ToTable("City");
            builder.HasOne(m => m.Province).WithMany(m => m.Cities).HasForeignKey(m => m.ProvinceId);

            builder.HasData(new City[]
            {
                new City(1,"آذربایجان شرقی",null,null,"041"),
                new City(2,"آذربایجان غربی",null,null,"044"),
                new City(3,"اردبیل",null,null,"045"),
                new City(4,"اصفهان",null,null,"041"),
                new City(5,"البرز",null,null,"076"),
                new City(6,"ایلام",null,null,"084"),
                new City(7,"بوشهر",null,null,"077"),
                new City(8,"تهران",null,null,"021"),
                new City(9,"چهارمحال و بختیاری",null,null,"038"),
                new City(10,"خراسان جنوبی",null,null,"056"),
                new City(11,"خراسان رضوی",null,null,"051"),
                new City(12,"خراسان شمالی",null,null,"058"),
                new City(13,"خوزستان",null,null,"061"),
                new City(14,"زنجان",null,null,"024"),
                new City(15,"سمنان",null,null,"023"),
                new City(16,"سیستان و بلوچستان",null,null,"054"),
                new City(17,"فارس",null,null,"071"),
                new City(18,"قزوین",null,null,"028"),
                new City(19,"قم",null,null,"025"),
                new City(20,"کردستان",null,null,"087"),
                new City(21,"کرمان",null,null,"034"),
                new City(22,"کرمانشاه",null,null,"083"),
                new City(23,"کهگیلویه و بویراحمد",null,null,"074"),
                new City(24,"گلستان",null,null,"017"),
                new City(25,"گیلان",null,null,"013"),
                new City(26,"لرستان",null,null,"066"),
                new City(27,"مازندران",null,null,"011"),
                new City(28,"مرکزی",null,null,"086"),
                new City(29,"هرمزگان",null,null,"076"),
                new City(30,"همدان",null,null,"081"),
                new City(31,"یزد",null,null,"035"),
            });
            builder.HasData(new City[]
            {
                          new City(32,"تهران",8,null,"021"),
                          new City(33,"شهریار",8,null,"021"),
                          new City(34,"اسلامشهر",8,null,"021"),
                          new City(35,"بهارستان",8,null,"021"),
                          new City(36,"پاکدشت",8,null,"021"),
                          new City(37,"ری",8,null,"021"),
                          new City(38,"قدس",8,null,"021"),
                          new City(39,"رباط کریم",8,null,"021"),
                          new City(40,"ورامین",8,null,"021"),
                          new City(41,"قرچک",8,null,"021"),
                          new City(42,"پردیس",8,null,"021"),
                          new City(43,"دماوند",8,null,"021"),
                          new City(44,"پیشوا",8,null,"021"),
                          new City(45,"شمیرانات",8,null,"021"),
                          new City(46,"فیروزکوه",8,null,"021"),
            });
        }
    }

}
