using System;

namespace OOProg
{
	// enum can be interpreted as an integer value.
	public enum Direction { Left, Forward, Right }

	// Abstract class cannot be instantiated.
	//public abstract class Vehicule
	public class Vehicule
	{
		// This is an attribute
		// Protected means it is accessible only in this class + child classes
		protected uint _wheelsCount = 0u;
		// This is a Property publicly accessible.
		public uint WheelsCount { get { return _wheelsCount; } }

		// This is a shorter way to add a property with the same level of protection (public read / protected write).
		public uint MaxSpeed { get; protected set; } = 0u; // property with default value.

		// Abstract method has no implementation.
		//public abstract void Move(Direction pDirection);
		public virtual void Move(Direction pDirection)
		{
			Console.WriteLine("Vehicule moved to direction : " + pDirection); // pDirection.ToString() called implicitly.
		}

		public override string ToString()
		{
			return "Vehicule : #Wheels(" + _wheelsCount + ") | Max speed (" + MaxSpeed + ")";
		}
	}

	// This child class inherit from Vehicule and can extend its functionalities.
	public class Car : Vehicule
	{
		// This a constructor.
		// It is called when instantiating the object.
		// Ex: Vehicule car = new Car();
		public Car()
		{
			_wheelsCount = 4u;
			MaxSpeed = 120u;
		}

		// Override means this method will be called instead of the one from base class.
		public override void Move(Direction pDirection)
		{
			//base.Move(pDirection); // you can call the method from the parent class if you want
			// and then add the code specific to the child class.
			Console.WriteLine("Car moved to direction : " + pDirection);
		}

		// All types derive from object by default, and can override the ToString() method.
		public override string ToString()
		{
			return "Car : #Wheels(" + _wheelsCount + ") | Max speed (" + MaxSpeed + ")";
		}
	}

	// Just another child class.
	public class Bike : Vehicule
	{
		public Bike()
		{
			_wheelsCount = 2u;
			MaxSpeed = 200u;
		}

		public override void Move(Direction pDirection)
		{
			Console.WriteLine("Bike moved to direction : " + pDirection);
		}

		public override string ToString()
		{
			return "Bike : #Wheels(" + _wheelsCount + ") | Max speed (" + MaxSpeed + ")";
		}
	}

	// Just another child class.
	public class Bus : Vehicule
	{
		public Bus()
		{
			_wheelsCount = 8u;
			MaxSpeed = 90u;
		}

		public override void Move(Direction pDirection)
		{
			Console.WriteLine("Bus moved to direction : " + pDirection);
		}

		public override string ToString()
		{
			return "Bus : #Wheels(" + _wheelsCount + ") | Max speed (" + MaxSpeed + ")";
		}
	}
}
