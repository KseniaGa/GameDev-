using System;

namespace ROBOTS
{

	public abstract class Box
	{
		//BOXES HAVE WEIGHT AND REWARD

		public Box(int w, int r)
		{
			this.Weight = w;
			this.Reward = r; 
		}

		public int Weight  { get; protected set; }
		public int Reward { get; protected set; }


		public abstract void specialFunction(String rName, Robot robot); 


		//public abstract int GetCost();

	}



	public abstract class BoxDecorator : Box
	{
		protected Box box;
		public BoxDecorator(int w,int r, Box box) : base(w, r)
		{
			this.box = box;
		}

	}


	public class CodedBox: BoxDecorator
	{

		//if S robot - go to Box, if C - 60% chance of decoding, if W - 10% 

		public CodedBox(Box b): base(b.Weight, b.Reward, b)
		{ }


		public override void specialFunction(String rName, Robot robot)
		{

			if (rName == "Cyborg")
			{
				//do coding probability function 
				
				String codingFunc()
				{
					Random rand = new Random();
					int chance = rand.Next(1, 101);

					if (chance <= 60) // probability of 60%
					{
						Console.WriteLine("BOX DECODED");

					}
					else
					{
						b.Weight = 0;
						b.Reward = 0;
						Console.WriteLine("BOX NOT DECODED");
					}

				} 

			}

			else if (rName == "WorkerRobot")
			{
				//do coding probability function  
				Random rand = new Random();
				int chance = rand.Next(1, 101);

				if (chance <= 10) // probability of 60%
				{
					Console.WriteLine("BOX DECODED");
				}
				else
				{
					b.Weight = 0;
					b.Reward = 0;
					Console.WriteLine("BOX NOT DECODED");
				}

			}

			else if (rName == "SmartRobot")
			{
				Console.WriteLine("BOX DECODED, BECAUSE YOU'RE SO SMART <3");
			}

			else
			{
				Console.WriteLine("DONT KNOW THIS ROBOT :( "); 
			}
		}



	} 

	public class ToxicBox: BoxDecorator
	{
		//toxic for cyborgs (if cyborg -battery ? and R + W = 0? )

		public ToxicBox(Box b) : base(b.Weight, b.Reward, b)
		{ }

		public override void specialFunction(String rName, Robot robot)
		{
			if (rName == "Cyborg")
			{
				robot.Battery = robot.Battery - 5;
				Console.WriteLine("DROP THAT BOX, IF YOU WANT TO LIVE"); 
			}

			else
			{
				Console.WriteLine("THIS BOX DOESN'T HURT YOU"); 
			}
		}



	}

	public class FragileBox : BoxDecorator
	{

		//weight 0, reward 0 ?? message - BOX BROKE 
		public ToxicBox(Box b) : base(b.Weight = 0, b.Reward = 0, b)
		{ }

		public override void specialFunction(String rName, Robot robot)
		{
			Console.WriteLine("OH NO, YOU GOT THE BROKEN BOX, NO REWARD FOR YOU !");
		}

	}


}