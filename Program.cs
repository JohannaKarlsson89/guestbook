/*
JOHANNAS GUESTBOOK
Johanna Karlsson /  STUDENT Mid Sweden University
*/
// Lite osäker på vad dessa gör
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace guestbook
{
  

    class Program
    {
        static void Main(string[] args)
        {
 
           Guestbook guestbook = new Guestbook();
            int i=0;

            while(true){
                Console.Clear();Console.CursorVisible = false;
                Console.WriteLine("Johannas Gästbok\n\n");
                Console.WriteLine("1. Lägg till skribent och meddelande\n");
                Console.WriteLine("2. Ta bort inlägg\n");
                Console.WriteLine("X. Avsluta\n");

             

                i=0;
                //For each element in Post make a new line
                foreach(Posts post in guestbook.getPosts()){
                    Console.WriteLine("[" + i++ + "] " + "Inlägg: " + post.Message +  "\nFörfattare: " + post.Author + "\n");
                }
//Waitng for user to put in 1,2 or X
    int inp = (int) Console.ReadKey(true).Key;
                switch (inp) {
                    case '1':
                        Console.Clear(); 
                        Console.CursorVisible = true; 
                        Console.Write("Ditt meddelande: ");
                        string message = Console.ReadLine();
                            if(String.IsNullOrEmpty(message) ) {
                          Console.Write("du måste fylla i ett meddelande ");
                          Console.ReadKey();
                          break;
                        }
              
                          Console.Write("Namn: ");
                         string author = Console.ReadLine();
                           if(String.IsNullOrEmpty(author)) {
                            Console.Write("du måste fylla i ett namn ");
                            Console.ReadKey();
                            break;
                          
                        }
                        Posts obj = new Posts();
                        obj.Message = message;
                        obj.Author = author;
                    
                     
                           guestbook.addPost(obj); 

                         break; 
                       
                    case '2': 
                     
                        Console.CursorVisible = true;
                        Console.Write("Ange index att radera: ");
                        string index = Console.ReadLine();
                       guestbook.delPost(Convert.ToInt32(index));
                        break;
                    
                        //88 istället för x
                    case 88: 
                    //End the application
                        Environment.Exit(0);
                        break;
                }
              
            }

        }
    }
}
