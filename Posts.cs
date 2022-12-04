
namespace guestbook {
    //Objekt for the class Guestbook each unique message and author

  public class Posts
    {
        //set and get for message are set to private
        private string message;   
        private string author;    
        public string Message
        {
            set {this.message = value;}
            get {return this.message;}
        }
//set and get for author
        public string Author {
            set {this.author = value;}
            get {return this.author;}
        }
    }
}