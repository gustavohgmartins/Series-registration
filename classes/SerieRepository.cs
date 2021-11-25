using System;
using System.Collections.Generic;
using Series_registration.Interfaces;

namespace Series_registration
{
    public class SeriesRepository : IRepository<Series>
    {
        private List<Series> seriesList = new List<Series>();
        public void add(Series entity)
        {
            seriesList.Add(entity);
            Console.WriteLine($"{entity.getTitle()} added successfully");
        }

        public void delete(int id)
        {
            foreach(Series elem in seriesList){
                if(elem.getId() == id){
                    Console.Write($"Are you sure you want to delete Id: {elem.getId()} Title: {elem.getTitle()} ? (Y/N)");
                    string answer = Console.ReadLine();
                    if(answer.ToUpper() == "Y"){
                        Console.WriteLine($"{elem.getTitle()} deleted successfully");
                        seriesList.RemoveAll(series => series.getId()==id);
                    return;
                    }
                    return;
                }
            };
            Console.WriteLine("No series with this id was found");
        }

        public Series getBy(string input, int by)
        {
            if(by == 1){
                foreach(Series elem in seriesList){
                    if(elem.getId() == Convert.ToInt32(input)){
                        return elem;
                    }
                };
                Console.WriteLine("No series with this id was found");
                return null;
            }
            else{
                foreach(Series elem in seriesList){
                    if(elem.getTitle().ToLower() == input.ToLower()){
                        return elem;
                    }
                };
                Console.WriteLine("No series with this title was found");
                return null;
            }
        }
        
        public List<Series> list()
        {
            seriesList.Sort((elem1,elem2) => elem1.getId().CompareTo(elem2.getId()));
            return seriesList;
        }

        public int nextId()
        {   
            if(seriesList.Count == 0){
                return 0;
            }
            seriesList.Sort((elem1,elem2) => elem1.getId().CompareTo(elem2.getId()));
            for(int i = 0; i < seriesList.Count; i++){
                if((i == 0) && (seriesList[i].getId() != 0)){
                    return seriesList[i].getId() - 1;
                }
                if(i<(seriesList.Count - 1)){
                    if(seriesList[i].getId() + 1 != seriesList[i+1].getId()){
                        return seriesList[i].getId() + 1;
                    }
                }
            }
            return seriesList.Count;
        }


        public void update(int id, Series entity)
        {
            for(int i = 0; i < seriesList.Count; i++){
                if(seriesList[i].getId()==id){
                    seriesList[i]=entity;
                    Console.WriteLine($"id {id} Updated Successfully");
                }
            }
        }
    }
}