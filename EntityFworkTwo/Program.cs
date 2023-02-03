using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFworkTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddFruit(new fandv(51, "name51", "fruit", "orange", 25));
            GetAllVegetables();
            
            Console.ReadLine();
        }
        static void AddFruit(fandv item) //принимает таблицу, добавляет объект
        {
            using (FruitsAndVegetablesEntities fandvEntities = new FruitsAndVegetablesEntities()) //название есть в Context.cs
            {
                //x - пустая переменная, пока не обращается к dataset
                fandv exist = fandvEntities.fandv.Where((x) => x.Id == item.Id && x.Name == item.Name).FirstOrDefault();
                if (exist == null)
                {
                fandvEntities.fandv.Add(item); //item - сущность класса таблицы  
                fandvEntities.SaveChanges();

                }
            }
        }
        static void GetAllVegetables()
        {
            using (FruitsAndVegetablesEntities fandvEntities = new FruitsAndVegetablesEntities())
            {
                List<fandv> list = fandvEntities.fandv.ToList();
                //foreach (fandv item in fandvEntities.fandv) ;
                foreach (fandv item in list)
                {
                    if (item.Type == "vegetables")
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
    }
}
