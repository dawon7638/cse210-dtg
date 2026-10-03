using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video(
            "How to Learn C#",
            "Code Academy",
            420
        );

        video1.AddComment(new Comment(
            "James",
            "This really helped me understand C#."
        ));

        video1.AddComment(new Comment(
            "Sarah",
            "Great explanation!"
        ));

        video1.AddComment(new Comment(
            "Mike",
            "Thanks for the tutorial."
        ));

        videos.Add(video1);


        Video video2 = new Video(
            "Building Your First Gaming PC",
            "Tech World",
            615
        );

        video2.AddComment(new Comment(
            "David",
            "This helped me build my first computer."
        ));

        video2.AddComment(new Comment(
            "Ashley",
            "What graphics card would you recommend?"
        ));

        video2.AddComment(new Comment(
            "Chris",
            "Great video!"
        ));

        videos.Add(video2);


        Video video3 = new Video(
            "Beginner Guitar Lesson",
            "Guitar Central",
            530
        );

        video3.AddComment(new Comment(
            "John",
            "I finally learned these chords."
        ));

        video3.AddComment(new Comment(
            "Emily",
            "This was easy to follow."
        ));

        video3.AddComment(new Comment(
            "Robert",
            "Looking forward to the next lesson."
        ));

        videos.Add(video3);


        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");
            Console.WriteLine();

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine();
        }
    }
}