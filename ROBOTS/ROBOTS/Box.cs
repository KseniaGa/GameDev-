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
		

		public abstract String specialFunction(String rName, Robot robot); 


		//public abstract int GetCost();

	}

	public class RegBox : Box
	{

		public static int getW()
		{
			Random rnd = new Random();
			int W = rnd.Next(5, 20);

			return W;
		}

		public static int getR()
		{
			Random rnd = new Random();
			int R = rnd.Next(1, 10);

			return R;
		}

		public RegBox() : base(getW(), getR())
		{
			
		}



		public override String specialFunction(string rName, Robot robot)
		{

			return "REG BOX";
		}
	}



	public abstract class BoxDecorator : Box
	{
		public Box box;
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

		

		public override String specialFunction(String rName, Robot robot)
		{

			

			if (rName == "C")
			{
				//do coding probability function 
				

					Random rand = new Random();
					int chance = rand.Next(1, 101);

					if (chance <= 60) // probability of 60%
					{
						return "BOX DECODED";

					}
					else
					{

					    return  "BOX NOT DECODED";
					}


			}

			else if (rName == "W")
			{
				//do coding probability function  
				Random rand = new Random();
				int chance = rand.Next(1, 101);

				if (chance <= 10) // probability of 10%
				{
					return "BOX DECODED";
				}
				else
				{

					return "BOX NOT DECODED";
				}

			}

			else if (rName == "S")
			{
				return "BOX DECODED";

			}

			else
			{
				return "DONT KNOW THIS ROBOT :( "; 
			}
		}



	} 

	public class ToxicBox: BoxDecorator
	{
		//toxic for cyborgs (if cyborg -battery ? and R + W = 0? )

		public ToxicBox(Box b) : base(b.Weight, b.Reward, b)
		{ }

		public override String specialFunction(String rName, Robot robot)
		{
			if (rName == "C")
			{
				robot.Battery = robot.Battery - 5;
				return "TOXIC ALERT"; 
			}

			else
			{
				return "OK"; 
			}
		}



	}

	public class FragileBox : BoxDecorator
	{

		//weight 0, reward 0 ?? message - BOX BROKE 
		public FragileBox(Box b) : base(b.Weight, b.Reward, b)
		{ }

		FragileBox b = null; 

		public override String specialFunction(String rName, Robot robot)
		{
			b.Weight = 0;
			b.Reward = 0;
			return "OH NO, YOU GOT THE BROKEN BOX, NO REWARD FOR YOU !";
		}

	}


}