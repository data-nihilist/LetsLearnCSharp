/*
    Object-oriented design is the part of crafting software where we decide...

            - Which objects should exist in our program
            - The classes each of those objects belong to
            - What responsibilities each class or object should handle
            - When objects should come into existence
            - When objects should go OUT of existence
            - Which objects must collaborate with or rely upon which other objects
            - How an object knows about the other objects it works with

    Requirement Gathering:

    The first step of building object-oriented systems is understanding what the software needs to do.
    Simply put - writing a sentence or two describing each feature should get you to where you're trying to go.
        This helps you and fellow programmers remain on the same page.
    
    For example, a couple requirements for the game Asteroids could be:
        "Asteroids drift through space at some specific velocity."
        "When a bullet hits an asteroid, the asteroid is removed from the game."

        We can augment these short sentences with specific, concrete examples

        Examples help us discover details that might have otherwise been missed and help ensure everyone understands things the same way:

            "An asteroid is at the coordinates (2, 4) with a velocity of (-1, 0). After one second passes, its coordinates should be (1, 4)."

            Even this simple example shows that positions and velocities are measured in two directions (side-to-side and top-to-bottom), and velocity is units/second.
    
    We do not need to collect every single requirement before moving forward.

    Software is best built a little at a time because our plans for the software evolve as they come together.
    You can sometimes benefit by having a long-term view of what might be needed later, but those long-term plans nearly always change along the way.
    That being said, there are situations where change is rare and knowing more details ahead of time is more beneficial.

    Designing The Software:

        Noun Extraction: Concepts that appear in the requirements will often lead to classes of objects in your design.
        Jobs or tasks that appear in the requirements will often lead to responsibilities that your software must be able to do.
        Some object in your design must eventually handle that responsibility.

        Not all nouns deserve to be classes in our program and not every important concept is explicitly stated in our requirements.
        It usually involves more work to discover which concepts and tasks are involved. But if you miss something - you can always change it later. Software is soft.
    
        Let's look at this Asteroids example again: "Asteroids drift through space at some specific velocity."
            
            The nouns asteroid, space, and velocity are all potential concepts that we may or may not make classes around, and the verb drift is a job that some 
            object (or several objects) in our system will need to do. We may have some thoughts on how we could start designing our program from this.
        
        You are not done designing until you have code that solves the problem and whose structure is something you can live with.
    
    Four (of many) Basic Design Evaluation Techniques:

        1. It has to work:
            Look carefully at each design that you come up with. Does it do what it was supposed to do? If not, it isn't a useful design.
        
        2. Prefer designs that convey meaning and intent:
            Programmers spend more time reading code than writing it.
            When you come back and look at the classes, objects, and their interactions in two weeks or two years, which of the choices will be most understandable?

            Of these four techniques, this is the most subjective.
        
        3. Designs should not contain duplication:
            If one design contains the same logic or data in more than once place, it is worse than one that does not.
            Anything you need to change would have to be modified in many different places instead of just one.

        4. Designs should not have unused or unnecessary elements:
            Make things as streamlined and straight forward as you can. Designs that add extra stuff "just in case" are worse than ones that are as simple as possible.
    
    Creating Code:

        Creating the actual code may give us more information, and we may realize that our initial pick for a design was not ideal.
        When this happens, we should adapt and change our plan. Software is soft, after all (has that been mentioned yet?).
*/

AsteroidsGame game = new AsteroidsGame();
game.Run();

public class Asteroid
{
    public float PositionX { get; private set; }
    public float PositionY { get; private set; }
    public float VelocityX { get; private set; }
    public float VelocityY { get; private set; }

    public Asteroid(float positionX, float positionY,
                    float velocityX, float velocityY)
    {
        PositionX = positionX;
        PositionY = positionY;
        VelocityX = velocityX;
        VelocityY = velocityY;
    }

    public void Update()
    {
        PositionX += VelocityX;
        PositionY += VelocityY;
    }
}

public class AsteroidsGame
{
    private Asteroid[] _asteroids;

    public AsteroidsGame()
    {
        _asteroids = new Asteroid[5];
        _asteroids[0] = new Asteroid(100, 200, -4, -2);
        _asteroids[1] = new Asteroid(-50, 100, -4, +3);
        _asteroids[2] = new Asteroid(0, 0, 2, 1);
        _asteroids[3] = new Asteroid(400, -100, -3, -2);
        _asteroids[4] = new Asteroid(200, -300, 0, 3);
    }

    public void Run()
    {
        while (true)
        {
            foreach (Asteroid asteroid in _asteroids)
                asteroid.Update();
        }
    }
}

/*
    What's bothering me:

        -The four properties of the Asteroid class are bothersome - variables that begin or end the same way often indicate that we're missing a class of some sort.
            We could make a Coordinate class or a Velocity class with X and Y properties and simplify that to two properties.
                The X and Y parts would make more sense as a single object.
        
        - Hardcoding starting locations means we play the same game every single time.
            The Random class would be a good solution for this problem.

        - Array instances keep the same size once created.
            Right now, we are okay to have a fixed list of asteroids but we will eventually be adding and removing asteroids from the list
            The List class is better than arrays for changing sizes and would be a good solution for this problem.
        
        -The while(true) loop.
            Until we have a way to win or lose the game, looping forever is fine, but this loop updates asteroids as fast as humanly (computerly?) possible.
            One pass leads right into the next.
            The AsteroidsGame class has that responsibility, and it does the job - just does it poorly.
                To wait a while between iterations or allow the asteroids to know how much time has passed and update it accordingly would be good improvements here.

    How To Collaborate:

        Objects collaborate by calling members (methods, properties, etc.) on the object they need help from.
        Calling a method is straightforward.
        The tricky part is how does an object know about its collaborators in the first place? There are a variety of ways this can happen;

            Creating New Objects:
                By creating a new instance with the 'new' keyword, an object gets a reference to the collaborating objects in the code.
                In the code above, these references to new Asteroid instances are put in an array and used later.
            
            Constructor Parameters:
                Having something else hand it the reference when the object is created as a constructor parameter.
                In the code above, we could have passed the asteroids to the game through its constructor like this:

                    public AsteroidGame(Asteroid[] startingAsteroids)
                    {
                        _asteroids = startingAsteroids;
                    }
                
                The main method, which creates our AsteroidsGame instance, would then make the game's asteroids.
                Come to think of it, creating the initial list of asteroids is a responsibility we never explicitly assigned to any object while planning!
                We originally placed that responsibility to the AsteroidsGame class, but we could (or should) create an AsteroidGenerator class to handle this instead.
                Passing in the object through a constructor parameter is a popular choice if an object needs another object from the beginning but can't or shouldn't 
                    just use 'new' to make a new one.
            
            Method Parameters:
                On the other hand, if an object only needs a reference to something for a single method, it can be passed in as a method parameter.
                If our design utilized an AsteroidDriftingSystem class, the game object might have given the asteroids to this object as a method parameter:

                    public class AsteroidDriftingSystem
                    {
                        public void Update(Asteroid[] asteroids)
                        {
                            foreach (Asteroid asteroid in asteroids)
                            {
                                asteroid.PositionX += asteroid.VelocityX;
                                asteroid.PositionY += asteroid.VelocityY;
                            }
                        }
                    }
            
            Asking Another Object:
                An object can also get a reference toa collaborator by asking a third object ot supply the reference.
                Let's say the AsteroidsGame had a public Asteroids property that returned the list of asteroids.
                    The AsteroidsDriftingSystem object could then take the game as a parameter, instead of the asteroids, 
                    and ask the game to supply the list by calling its Asteroids property:

                        public void Update(AsteroidsGame game)
                        {
                            foreach (Asteroid asteroid in game.Asteroids)
                            {
                                asteroid.PositionX += asteroid.VelocityX;
                                asteroid.PositionY += asteroid.VelocityY;
                            }
                        }
            Supplying the Reference via Property or Method:
                Suppose we can't supply a reference to an object in the constructor but need it for more than one method.
                Another option is to have the outside world supply the reference through a property or method call then save off the reference to a field for later use.
                    The AsteroidDriftingSystem class could have done this like so:

                        public class AsteroidDriftingSystem
                        {
                            // Initialize this to an empty array, so we know it will never by null.
                            public Asteroid[] Asteroids { get; set; } = new Asteroid[0];

                            public void update()
                            {
                                foreach (Asteroid asteroid in Asteroids)
                                {
                                    asteroid.PositionX += asteroid.VelocityX;
                                    asteroid.PositionY += asteroid.VelocityY;
                                }
                            }
                        }

                        Before this object's Update method runs, the AsteroidsGame object must ensure this property has been set.
                            It only needs to be set once, not before every Update() call.
            
            Static Members:
                A final approach would be to use a static property, method, or field.
                If it is public, these can be reached from anywhere.
                For example, we could make this property in AsteroidsGame to store the last created game:

                    public class AsteroidsGame
                    {
                        public static AsteroidsGame Current { get; set; }
                        // ...
                    }

                    When the main method runs, it can assign a value to this:

                        AsteroidsGame Current = new AsteroidsGame();

                        Then AsteroidDriftingSystem can access the game through the static property:

                            public void Update()
                            {
                                foreach (Asteroid asteroid in AsteroidsGame.Current.Asteroids)
                                {
                                    asteroid.PositionX += asteroid.VelocityX;
                                    asteroid.PositionY += asteroid.VelocityY;
                                }
                            }

                            In most circumstances, it's recommended not to take this approach because we're working with global state, but it has it's uses nonetheless.
    
    

*/