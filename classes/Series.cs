using System;
namespace Series_registration
{
    public class Series : BaseEntity
    {
        private Genre genre {get; set;}
        private string title {get; set;}
        private string description {get; set;}
        private int year {get; set;}

        public Series(int id, Genre genre, string title, string description, int year){
            this.id = id;
            this.genre = genre;
            this.title = title;
            this.description = description;
            this.year = year;
        }

        public override string ToString(){
            string content = $"{Environment.NewLine}";
            content += $"Title: {this.title}{Environment.NewLine}";
            content += $"Description: {this.description}{Environment.NewLine}";
            content += $"Genre: {this.genre}{Environment.NewLine}";
            content += $"Released: {this.year}{Environment.NewLine}";
            return content;
        }
        public string getTitle(){
            return this.title;
        }
        public int getId(){
            return this.id;
        }
    }
}