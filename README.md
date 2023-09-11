<div align="center">
<h1>LetsLearnCSharp!</h1>

C# ("See-sharp") is a general-purpose, high-level programming language supporting multiple paradigms.
C# encompasses static typing, strong typing, lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based), and component-oriented programming disciplines.
</div>


<h2>Why am I learning C#?</h2>
To put it simply: I want to make video games. The Unity engine in part depends on C# (and C++, we'll tackle that later).
So, in order to make rad games (and become a better programmer as I do it), I should learn C#.
This is step one of many on this journey :)

Quick note: You don't NEED to learn C# to use Unity!
But, if you want to become a better Unity developer, having a solid understanding of C# will be a huge bonus.

<h2>How am I learning C#?</h2>
Originally I was going to try and find a decent, well-reviewed textbook. That's how I learned JavaScript before beginning my apprenticeship at Launch Academy
(see: <a href="https://eloquentjavascript.net/" target="_blank">Eloquent JavaScript by Marijn Haverbeke, bookmark it).</a>
I'm a big fan of Marijn's work and how effective the process of: Read, Experiment, Proceed is for a learner of my style.

Enter: <a href="https://www.freecodecamp.org/learn/foundational-c-sharp-with-microsoft/" target="_blank">freecodecamp.org's latest offering</a>

This is what this repository will be hosting: My process through completeing the (New) Foundational C# with Microsoft certification.

I wanted to ensure my progress was being stored somewhere other than my local machine. This 2017 macbook air can only get me so far beyond this point (Fall 2023).

If you're new to C#, like I am, or are interested in discussing all things video games (and what makes them such impressive feats of engineering), message me on <a href="https://www.linkedin.com/in/matthew-mccredy/" target="_blank">Linkedin!</a>

<h2>Environment Config</h2>
Setting up your IDE for writing and executing C# programs is very easy to do.
I'm writing and running all of this via VS Code (though you can also use Mono if that's more your jam).
Here's my typical set-up in _ easy steps (_ if we remove the initial config):

<ol>
<li>You need to be able to write C# on your machine:
<ul>
  <li>Open VS Code</li>
  <li>Navigate to the Extensions tab of your left</li>
  <li>Search for: "C#"</li>
  <li>Click "Install"</li>
</ul>
</li>
<li>
  You need a way to run C# on your machine: .NET ("Dot-Net") is the framework and runtime that C# programs are built with and run on.
  <ul>
    <li>In your VS Code</li>
    <li>Navigate to the Extensions tab of your left</li>
    <li>Search for: ".NET Runtime Install Tool"</li>
    <li>CLick "Install"</li>
  </ul>
</li>
<h4>Fun Fact: The "C# Dev Kit" you saw when searching for C# can also be installed for a 'one stop shop' sort of deal.</h4>
<li>
  Close VS Code (this is integral as the program needs to be rebooted after these plugins are installed).
</li>
<li>
  Open your terminal and create a new directory to host your C# files: $mkdir <directory_name> (I named mine "c#," you can name yours whatever your heart desires.)
</li>
<li>
  Navigate within this new directory from the command line: ~/<directory_name> $mkdir exampleFolder
</li>
<li>
  Once you've created a directory to hold some C# program files, open your VS Code.
</li>
<li>
  From VS Code, select File at the top of your desktop screen, then "Open"
</li>
<li>
  Now, you should be in an empty VS Code session named <directory_name>.
</li>
<li>
  Select Terminal at the top of your desktop screen, then "New Terminal"  This will open the VS Code integrated terminal.
</li>
<li>
  Finally, from within this directory's root path of the integrated terminal: $dotnet new console -o ./<project_name> 
</li>
</ol>
Tip: <project_name> should be representative of what you're accomplishing with this project. If it's a "firing range" type of deal, name your new project that!

<h3>Now you should have a fully templated C# program - wahoo!</h3>

<h4>You should get a pop-up from the .NET extension we installed asking if you'd like to configure a project suite: Accept this offering!</h4>

<h2>Let's test this out:</h2>
<ol>
  <li>
    In your integrated terminal, ensure you're in the root of your project folder: ~/root/<directory_name>/<project_name> $
  </li>
  <li>
    Run the .NET build command: ~/root/<directory_name>/<project_name> $dotnet build
  </li>
      This pre-compiles any existing code and looks for errors.
  <li>
    Run the .NET run command: ~/root/<directory_name>/<project_name> $dotnet run
  </li>
      This will execute any code living in the Program.cs file that the ```dotnet new console -o``` command created for you
</ol>

<h3>At this point, "Hello World!" should be in your terminal output. You can safely delete everything in that file and start coding!</h3>
