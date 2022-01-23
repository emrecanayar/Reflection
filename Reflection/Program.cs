using Reflection;
using System.Reflection;

Student student = new Student();

//Class içerisinde bulunan propertylere erişmek için aşağıdaki yapı kullanılır.
student.GetType().GetProperties().ToList().ForEach(p =>
{
    Console.WriteLine($"{p.Name},{p.PropertyType}");
});

//Class içerisinde bulunan metotlara erişip, Invoke metodu ile aşağıdaki gibi çalıştırabiliriz.
student.GetType().GetMethods().ToList().ForEach(m =>
{
    if (m.Name == "SalaryCalculate")
    {
        var result = m.Invoke(student, new object[] { 10, 13 });
        Console.WriteLine(result);
    }
});

//Class içerisnde bulunan propetylere, Reflection ile değer atamak istersek aşağıdaki gibi atayabiliriz.

student.GetType().GetProperties().ToList().ForEach(p =>
{
    if (p.Name == "StudentNo")
        p.SetValue(student, "936155");
    else if (p.Name == "FirstName")
        p.SetValue(student, "Emre Can");
    else if (p.Name == "LastName")
        p.SetValue(student, "Ayar");


});
Console.WriteLine($"{student.FirstName},{student.LastName},{student.StudentNo}");


//Class içerisinde tanımlı şekilde bulunan propetylerin değerlerini okumak için aşağıdaki gibi GetValue metodunu kullanabiliriz.
Student student2 = new Student() { FirstName = "Mert Can", LastName = "Ayar", StudentNo = "556193" };

student.GetType().GetProperties().ToList().ForEach(p =>
{
    if (p.Name == "StudentNo")
        Console.WriteLine($"Student No : {p.GetValue(student2)} ");
    else if (p.Name == "FirstName")
        Console.WriteLine($"FirstName  : {p.GetValue(student2)} ");
    else if (p.Name == "LastName")
        Console.WriteLine($"LastName   : {p.GetValue(student2)} ");


});


//Assembly sınıfından faydalanarak içerisindeki bilgileri Reflection ile almak.

Assembly assembly = Assembly.GetExecutingAssembly();
foreach (var item in assembly.GetTypes())
{
    Console.WriteLine($"{item.Namespace} , {item.Name}, {item.FullName}");
    foreach (var property in item.GetProperties())
    {
        Console.WriteLine($"{property.PropertyType}, {property.Name}");
    }
}

