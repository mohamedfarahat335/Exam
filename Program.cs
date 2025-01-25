using System;
using System.Collections.Generic;

namespace Exam
{
    // Base Question Class
    public abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public List<Answer> Answers { get; set; }
        public int RightAnswerId { get; set; }

        public Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
            Answers = new List<Answer>();
        }

        public abstract void DisplayQuestion();
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
