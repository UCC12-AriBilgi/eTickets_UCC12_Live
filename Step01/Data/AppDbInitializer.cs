using eTickets.Models;
using eTickets.Data.Enum;



namespace eTickets.Data
{
    // Burası fake/dummy data üretecek

    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope= applicationBuilder.ApplicationServices.CreateScope()) // Kapsam belirliyor
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                // Önceki adımlarda vt yi boş da olsa yaratmış olduk.

                context.Database.EnsureCreated(); // VT var mı/ yok mu

                //Cinema tablosu için
                if (!context.Cinemas.Any()) // içinde kayıt var/yok
                {
                    // eğer kayıt yoksa buraya düşecek o yüzden !(not) operatörünü koyduk
                    // Yeni bazı kayıtlar bölümü

                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        // 1.Kayıt
                        new Cinema()
                        {
                            Name="Cinema 1",
                            Logo="http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description="Burası Cinema 1 için bir açıklamadır."
                        },

                        new Cinema()
                        {
                            Name="Cinema 2",
                            Logo="http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description="Burası Cinema 2 için bir açıklamadır."
                        },
                        new Cinema()
                        {
                            Name="Cinema 3",
                            Logo="http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description="Burası Cinema 3 için bir açıklamadır."
                        },
                        new Cinema()
                        {
                            Name="Cinema 4",
                            Logo="http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description="Burası Cinema 4 için bir açıklamadır."
                        },
                        new Cinema()
                        {
                            Name="Cinema 5",
                            Logo="http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description="Burası Cinema 5 için bir açıklamadır."
                        }
                    });

                    context.SaveChanges(); // Yukarda girdiğim bilgiler VT deki Cinemas tablosuna yazılacak.


                }

                //Actor tablosu için
                if (!context.Actors.Any()) // içinde kayıt var/yok
                {
                    // eğer kayıt yoksa buraya düşecek o yüzden !(not) operatörünü koyduk
                    // Yeni bazı kayıtlar bölümü

                    context.Actors.AddRange(new List<Actor>()
                    {
                        // 1.Kayıt
                        new Actor()
                        {
                            FullName="Actor 1",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-1.jpeg",
                            Bio="Burası Actor 1 için bir bio dur."
                        },
                        new Actor()
                        {
                            FullName="Actor 2",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-2.jpeg",
                            Bio="Burası Actor 2 için bir bio dur."
                        },
                        new Actor()
                        {
                            FullName="Actor 3",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-3.jpeg",
                            Bio="Burası Actor 3 için bir bio dur."
                        },
                        new Actor()
                        {
                            FullName="Actor 4",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-4.jpeg",
                            Bio="Burası Actor 4 için bir bio dur."
                        },
                        new Actor()
                        {
                            FullName="Actor 5",
                            ProfilePictureURL="http://dotnethow.net/images/actors/actor-5.jpeg",
                            Bio="Burası Actor 5 için bir bio dur."
                        }

                    });

                    context.SaveChanges(); // Yukarda girdiğim bilgiler VT deki Actors tablosuna yazılacak.


                }
            }




        }
    }
}
