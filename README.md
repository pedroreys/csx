csx, a C# repl
===

No matter what you use - ConsoleApplications, Test Methods, whatever - executing ad hoc C# code sucks. 

We *need* a repl. Inspired by [scriptcs](https://github.com/scriptcs/scriptcs) I decided to see if I can [Roslyn](http://msdn.microsoft.com/en-us/vstudio/hh543936) to build one.

At this point this is just an experiment.


Installing
===

csx is a simple executable. Just add it to your path and you should be good to go.

Running
===
with csx on you path, do:

    c:>csx
    >1 +3
    4
    >var foo = "bar";    
    >foo
    bar
    >var fizz = "buzz";
    >fizz
    buzz
    >fizz = foo;
    >fizz
    bar
    >exit()
    c:>
