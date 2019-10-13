using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROBOTS
{
	class Program
	{
		static void Main(string[] args)
		{

			RobotFactory rb = new RobotFactory();

			Robot rob =  rb.makeRobot();
				
			Console.WriteLine(rob.getName()); 
			Console.ReadLine();

			MultiPult mPult = new MultiPult();

			mPult.SetCommand(0, new MakeStepCommand(rob));
			mPult.SetCommand(1, new BOXCommand(rob));


			while (rob.stepHist.Count <= 10)
			{
				mPult.PressButton(0);

				Console.WriteLine(rob.stepHist.Count); 

				Console.ReadLine();

				mPult.PressButton(1);

				//Console.ReadLine();

			}

		}
	}
}
