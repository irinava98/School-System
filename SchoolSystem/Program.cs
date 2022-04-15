using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SchoolSystem;
using System;
public class Program
{    
    public async static Task Main(string[] args)
    {
        var wr = new Writer();
        //wr.Create();
        //wr.Read();
        //wr.Update();
        //wr.Delete();
        

        //DateTime birthdate = new DateTime(1994, 3, 3);
        //var disconnectedEntity = new Student { Id = 1, FristName = "Irina", MiddleName = "Vladimirova", LastName = "Atanasova", Birthdate = DateTime.SpecifyKind(birthdate, DateTimeKind.Utc) };



        using (var context = new SchoolSystemDbContext())
        {
            // Unchanged State

            /*

            var student = context.Students.First();
            DisplayStates(context.ChangeTracker.Entries());

            */


            //Added State

            
            DateTime birthdate = new DateTime(1994, 3, 3);

            var student2 = new Student { FristName = "Irina", MiddleName = "Vladimirova", LastName = "Atanasova", Birthdate = DateTime.SpecifyKind(birthdate, DateTimeKind.Utc) };


            /*
           context.Add(student2);
            var entr1 = context.ChangeTracker.Entries();

            context.SaveChanges();

            var entr2 = context.ChangeTracker.Entries();

            student2.FristName = "Gencho";

            var entr3 = context.ChangeTracker.Entries();
            */

            //DisplayStates(context.ChangeTracker.Entries());



            //Modified State

            /*
            var student = context.Students.First();
            student.LastName = "LastName changed";

            DisplayStates(context.ChangeTracker.Entries());

            */

            //Deleted State
            /*
            
            var student = context.Students.First();
            context.Students.Remove(student);

            //DisplayStates(context.ChangeTracker.Entries());

            var entr1 = context.ChangeTracker.Entries();
            context.SaveChanges();

            var entr2 = context.ChangeTracker.Entries();
            */


            //Detached State

            // Console.Write(context.Entry(disconnectedEntity).State.ToString());





            await DeleteById<Course>(3);
             
           
           


            

            //DisplayStates(context.ChangeTracker.Entries());


        }




    }

    public static void DisplayStates(IEnumerable<EntityEntry> entries)
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: { entry.State.ToString()}");
        }
    }

    public async static Task DeleteById<T>(int id)
        where T:class,IIdentifiable
    {
        using (var context = new SchoolSystemDbContext())
        {
            var entity = await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if(entity!=null)
            {
                context.Remove(entity);
            }
            

            await context.SaveChangesAsync();
           

        }
    }

}
