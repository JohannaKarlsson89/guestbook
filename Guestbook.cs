using System;
using System.Collections.Generic;
using System.IO;

using System.Text.Json;

    namespace guestbook
{
    public class Guestbook 
    {
        //Varibale for the JSON-file that stores the Guestbook-post
        private string filename = @"guestbook.json";
        //List for all posts - Points to the class Posts in the file Post.cs

                private List<Posts> posts = new List<Posts>();
//constructor that checks if json-file exists
        public Guestbook(){ 
            if(File.Exists(@"guestbook.json")==true){ // If stored json data exists then read
                string jsonString = File.ReadAllText(filename);
                //Take the json-string and puts in the varible posts
                posts = JsonSerializer.Deserialize<List<Posts>>(jsonString);
            }
        }
       
        //Method to add a new Post - with a post object
            public Posts addPost(Posts post){
                //Add is method that can be used wwith lists
            posts.Add(post);
            //Method to make it text - serialisera data (Lagra på svenska)
            marshal();         
            return post;
        }
        //Method to delete a Post 
             public int delPost(int index){
            //RemoveAt is a method that can be used with lists
            posts.RemoveAt(index);
            marshal();
            return index;
        }
        
        //Method to Get the whole array of Posts
        public List<Posts> getPosts(){
            return posts;
        }
        //Method to serilize the object

        private void marshal()
        {
            // Serialize all the objects and save to file
            var jsonString = JsonSerializer.Serialize(posts);
            File.WriteAllText(filename, jsonString);
        }
    }
    
    }