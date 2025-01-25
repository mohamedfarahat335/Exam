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

    // Derived Question types
    public class TrueOrFalseQuestion : Question
    {
        public TrueOrFalseQuestion(string header, string body, int mark) : base(header, body, mark) { }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header}: {Body} (Mark: {Mark})");
            Console.WriteLine("1. True\n2. False");
        }
    }
    public class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark) : base(header, body, mark) { }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header}: {Body} (Mark: {Mark})");
            for (int i = 0; i < Answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Answers[i].AnswerText}");
            }
        }
    }

    // Answer class
    public class Answer
    {
        public int AnswerId_ans { get; set; }
        public string AnswerText_ans { get; set; }

        public Answer(int id, string text)
        {
            AnswerId_ans = id;
            AnswerText_ans = text;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
