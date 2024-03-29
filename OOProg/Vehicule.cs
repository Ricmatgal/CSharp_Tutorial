﻿using System;

namespace OOProg
{
	// an enum can be :
	// - interpreted as an integer value (Left = 0, Forward = 1, Right = 2).
	// - easyly converted to a string using the method ToString().
	public enum Direction { Left, Forward, Right }

	// EXERCISE 1
	// Create a class Vehicule with :
	// - an attribute wheelsCount
	// - a property MaxSpeed
	// - a method returning void, with a parameter of type Direction, called Move. This method should print "Vehicule moved to direction : " + direction(parameter).
	// - a method returning a string called ToString. This method should print the name of the class and the values of its attributes.
	#region CORRECTION 1
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

		//public float RotationSpeed { get; set; }
		// Verbose way to do the same thing as property.
		//private float _rotationSpeed;
		//public void SetRotationSpeed(float pRotationSpeed)
		//{
		//	_rotationSpeed = pRotationSpeed;
		//}
		//public float GetRotationSpeed()
		//{
		//	return _rotationSpeed;
		//}

		// Abstract method has no implementation.
		//public abstract void Move(Direction pDirection);

		public virtual void Move(Direction pDirection)
		{
			Console.WriteLine("Vehicule moved to direction : " + pDirection); // pDirection.ToString() called implicitly.
		}

		public virtual void Rotate(float pAngle)
		{
			Console.WriteLine("Vehicule rotated by {0} degrees", pAngle);
		}

		public override string ToString()
		{
			return "Vehicule : #Wheels(" + _wheelsCount + ") | Max speed (" + MaxSpeed + ")";
		}
	}
	#endregion

	// This child class inherit from Vehicule and can extend its functionalities.
	public class Car : Vehicule
	{
		// This a constructor.
		// It is called when instantiating the object.
		// Ex: Vehicule car = new Car();
		// Ex2: Car car = new Car();
		public Car()
		{
			_wheelsCount = 4u;
			MaxSpeed = 120u;
		}

		// Override means this method will be called instead of the one from the parent (base) class.
		public override void Move(Direction pDirection)
		{
			// you can call the method from the parent (base) class if you want
			//base.Move(pDirection);
			// and then add the code specific to the child class.
			Console.WriteLine("Car moved to direction : " + pDirection);
		}

		public override void Rotate(float pAngle)
		{
			Console.WriteLine("Car rotated by {0} degrees", pAngle);
		}

		// All types inherit from object by default, and can override the ToString() method.
		public override string ToString()
		{
			return "Car : #Wheels(" + _wheelsCount + ") | Max speed (" + MaxSpeed + ")";
		}
	}

	// EXERCISE 2
	// Create 2 others child classes:
	// - a class Bike with 2 wheels and max speed 45.
	// - a class Bus with 8 wheels and max speed 90.

	#region CORRECTION 2
	// Just another child class.
	public class Bike : Vehicule
	{
		public Bike()
		{
			_wheelsCount = 2u;
			MaxSpeed = 45u;
		}

		public override void Move(Direction pDirection)
		{
			Console.WriteLine("Bike moved to direction : " + pDirection);
		}

		public override void Rotate(float pAngle)
		{
			Console.WriteLine("Bike rotated by {0} degrees", pAngle);
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

		public override void Rotate(float pAngle)
		{
			Console.WriteLine("Bus rotated by {0} degrees", pAngle);
		}

		public override string ToString()
		{
			return "Bus : #Wheels(" + _wheelsCount + ") | Max speed (" + MaxSpeed + ")";
		}
	}
	#endregion
}
