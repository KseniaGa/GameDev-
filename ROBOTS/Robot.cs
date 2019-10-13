using System;

namespace ROBOTS
{
	public abstract class Robot
	{

		//public Robot() { }

		private String name;

		public String getName()
		{ return name; }

		public void setName(String newName)
		{ name = newName; }

		public int Battery = 0;
		public int WeightCapacity = 0;

		public void setWC(int newWC)
		{ WeightCapacity = newWC; }

		public void setBattery(int newBattery)
		{ Battery = newBattery; }



		public void StepForward(Robot robot)
		{
			robot.Battery--;
		}

		public void StepBackwards(Robot robot)
		{

			robot.Battery--;
		}

		public void pickUpBox(Robot robot)
		{
			robot.WeightCapacity--;
			//PLUS REWARD 
		}

		public void dropBox(Robot robot)
		{
			//MINUS REWARD 
			robot.WeightCapacity++;

		}

	}

}