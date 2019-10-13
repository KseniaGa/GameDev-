using System;
using System.Collections.Generic;

namespace ROBOTS
{
	public abstract class Robot
	{

		private String name;

		public int TotalReward = 0;
		public int Battery = 0;
		public int WeightCapacity = 0;

		public LinkedList<int> stepHist = new LinkedList<int>();

		public String getName()
		{ return name; }

		public void setName(String newName)
		{ name = newName; }

		public void setWC(int newWC)
		{ WeightCapacity = newWC; }

		public void setBattery(int newBattery)
		{ Battery = newBattery; }

		public void StepForward(Robot robot)
		{

			if (robot != null)
			{

				robot.Battery--;

				if (robot.stepHist.Count == 0)
				{
					Console.WriteLine("START OF THE GAME");
					robot.stepHist.AddFirst(1);
				}

				else if (robot.stepHist.Last.Value == 10)
				{
					Console.WriteLine("YOU'VE REACHED THE END OF THE LEVEL");
					gameOver(robot);
				}

				else
				{
					int step = robot.stepHist.Last.Value + 1;
					stepHist.AddLast(step);
				}

			}
		}

		public void StepBackwards(Robot robot)
		{
			if (robot != null)
			{
				robot.Battery--;
				robot.stepHist.RemoveLast();

			}
		}

		LinkedList<Box> bHist = new LinkedList<Box>();

		public void pickUpBox(Robot robot)
		{
			if (robot != null) { 

			int getBoxType()
			{
				Random rnd = new Random();
				int boxType = rnd.Next(1, 4);
				return boxType;
			}

			if (getBoxType() == 1)
			{
				Console.WriteLine("YOU GOT REG BOX");
				Box b = new RegBox();
				robot.Battery = robot.Battery - b.Weight;
				robot.TotalReward = robot.TotalReward + b.Reward;

				robot.bHist.AddLast(b);
			}

			else if (getBoxType() == 2)
			{
				Console.WriteLine("YOU GOT CODED BOX :O");
				Box b = new CodedBox(new RegBox());
				String SF = b.specialFunction(robot.getName(), robot);

				if (SF == "BOX DECODED")
				{
					Console.WriteLine("BOX DECODED");
					robot.Battery = robot.Battery - b.Weight;
					robot.TotalReward = robot.TotalReward + b.Reward;

					robot.bHist.AddLast(b);
				}

				else if (SF == "BOX NOT DECODED")
				{
					Console.WriteLine("BOX NOT DECODED, MOVE FORWARD");
				}


			}

			else if (getBoxType() == 3)
			{
				Console.WriteLine("YOU GOT TOXIC BOX :O");
				Box b = new ToxicBox(new RegBox());
				String SF = b.specialFunction(robot.getName(), robot);

				if (SF == "TOXIC ALERT")
				{
					Console.WriteLine("TOXIC, -5 BATTERY");
					robot.Battery = robot.Battery - b.Weight;
					robot.TotalReward = robot.TotalReward + b.Reward;

					robot.bHist.AddLast(b);
				}

				else if (SF == "OK")
				{
					Console.WriteLine("BOX IS TOXIC, BUT DOESN'T HURT YOU ");
					robot.Battery = robot.Battery - b.Weight;
					robot.TotalReward = robot.TotalReward + b.Reward;
					robot.bHist.AddLast(b);
				}

			}

			else
			{
				Console.WriteLine("YOU GOT FRAGILE BOX :O");
				Box b = new FragileBox(new RegBox());
				b.specialFunction(robot.getName(), robot);
				robot.bHist.AddLast(b);

			}


			if ((robot.Battery < 0) & (robot.WeightCapacity < 0))
			{
				gameOver(robot);
			}

		     }
		}

		public void dropBox(Robot robot)
		{
			if (robot != null)
			{

				//MINUS REWARD 
				Box b = robot.bHist.Last.Value;

				robot.Battery = robot.Battery + b.Weight;
				robot.WeightCapacity = robot.WeightCapacity + b.Weight;
				robot.TotalReward = robot.TotalReward - b.Reward;

				//REMOVING LAST BOX FROM BOX HISTORY 
				robot.bHist.RemoveLast();

				Console.WriteLine("BOX DROPPED");

				if ((robot.Battery < 0) & (robot.WeightCapacity < 0))
				{
					gameOver(robot);
				}

			}

		}

		public void gameOver(Robot robot)
		{
			Console.WriteLine(robot.TotalReward);
			Console.WriteLine("GAME OVER ... ");
			//robot = null;
			// GC.Collect(); 

		}
	}

}