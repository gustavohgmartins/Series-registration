using System;
using System.Linq;
using System.Collections.Generic;


namespace Series_registration
{
    class Program
    {   
        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args)
        {
            try{
                string[] options = {"1","2","3","4","5","C","X"};
                string userInput = getUserInput();
                while(userInput != "X"){
                    if(options.Contains(userInput)){
                        switch(userInput){
                            case "1":
                                listSeries();
                                break;
                            case "2":
                                addSeries();
                                break;
                            case "3":
                                updateSeries();
                                break;
                            case "4":
                                deleteSeries();
                                break;
                            case "5":
                                seriesOverview();
                                break;
                            case "C":
                                Console.Clear();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        userInput = getUserInput();
                    }
                    else{
                        Console.WriteLine("\nEnter a valid option number");
                        userInput = getUserInput();

                    }
                }
                Console.WriteLine("Thank you for choosing our service\n");
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
        }

        private static void seriesOverview()
        {
            Console.WriteLine("SERIES OVERVIEW");
            Console.Write("Want to search by Id(1) or Title(2)?");
            string input = Console.ReadLine();
                if(input == "1"){
                    try{
                        Console.Write("id: ");
                        string inputId = Console.ReadLine();
                        var series = repository.getBy(inputId, 1);
                        Console.WriteLine(series);
                    }
                    catch{
                        Console.WriteLine("\nThe Id must be a integer number");
                    }
                }
                else if(input == "2"){
                    Console.Write("Title: ");
                    try{
                        string inputId = (Console.ReadLine());
                        var series = repository.getBy(inputId, 2);
                        Console.WriteLine(series);
                    }
                    catch(Exception e){
                        Console.WriteLine(e.Message);
                    }
                }
                else{
                    Console.WriteLine("\nType 1 or 2\n");                 
                }
        }

        private static void deleteSeries()
        {
            try{
                Console.WriteLine("DELETE SERIES");
                Console.Write("id: ");
                int inputId = Convert.ToInt32(Console.ReadLine());
                repository.delete(inputId);
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("\nEnter a valid id"); 
            }
        }

        private static void updateSeries()
        {
            try{
                Console.WriteLine("UPDATE SERIES");
                Console.Write("id: ");
                int inputId = Convert.ToInt32(Console.ReadLine());
                var seriesList = repository.list();
                List<int> seriesIds = new List<int>();
                seriesList.ForEach(elem => {
                    seriesIds.Add(elem.getId());
                });
                    if(seriesIds.Contains(inputId)){
                        foreach(int i in Enum.GetValues(typeof(Genre))){
                            Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre),i)}");
                        }
                        Console.Write("\nEnter one of the genres above: ");
                        int inputGenre = Convert.ToInt32(Console.ReadLine());
                        List<int> options = new List<int>();
                        foreach(int i in Enum.GetValues(typeof(Genre))){
                            options.Add(i);
                        }
                        if(options.Contains(inputGenre)){
                            Console.Write("Title: ");
                            string inputTitle = Console.ReadLine();
                            Console.Write("Release year: ");
                            int inputYear = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Description: ");
                            string inputDescription = Console.ReadLine();
                            Series editedSeries = new Series(inputId, (Genre)inputGenre, inputTitle, inputDescription, inputYear);
                        
                            repository.update(inputId,editedSeries);
                        }
                        else{
                            Console.WriteLine("\nEnter a valid genre number");                 
                        }
                    }
                    else{
                        Console.WriteLine("\nNo series with this id was found");
                    }
                
            }
            catch{
                Console.WriteLine("\nThe fields 'Genre', 'Released' and 'id', only accept integer numbers");
            }
        }

        private static void addSeries()
        {
            try{
                Console.WriteLine("ADD NEW SERIES");
                foreach(int i in Enum.GetValues(typeof(Genre))){
                    Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre),i)}");
                }
                Console.Write("\nEnter one of the genres above: ");
                int inputGenre = Convert.ToInt32(Console.ReadLine());
                List<int> options = new List<int>();
                foreach(int i in Enum.GetValues(typeof(Genre))){
                    options.Add(i);
                }
                if(options.Contains(inputGenre)){
                    Console.Write("Title: ");
                    string inputTitle = Console.ReadLine();
                    Console.Write("Release year: ");
                    int inputYear = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Description: ");
                    string inputDescription = Console.ReadLine();
                    Series newSeries = new Series(repository.nextId(), (Genre)inputGenre, inputTitle, inputDescription, inputYear);
                
                    repository.add(newSeries);
                }
                else{
                    Console.WriteLine("\nEnter a valid genre number");                 
                }

            }
            catch(Exception e){
                Console.WriteLine("\nThe fields 'Genre' and 'Released', only accept integer numbers");
            }
        }

        private static void listSeries()
        {
            var seriesList = repository.list();
            if(seriesList.Count == 0){
                Console.WriteLine("No series registered");
                return;
            }
            Console.WriteLine("SERIES LIST");
            seriesList.ForEach(elem => {
                Console.WriteLine($"id {elem.getId()} - {elem.getTitle()}");
            });
        }

        private static string getUserInput(){
            Console.WriteLine();
            Console.WriteLine("Select one of the following options:");
            Console.WriteLine("1- Series list");
            Console.WriteLine("2- Add series");
            Console.WriteLine("3- Update series");
            Console.WriteLine("4- Delete series");
            Console.WriteLine("5- Series Overview");
            Console.WriteLine("C- Clear console");
            Console.WriteLine("X- Exit");
            Console.WriteLine("");

            string userInput = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userInput;
        }
    }
}
