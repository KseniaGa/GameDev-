﻿using System;
using System.Collections.Generic;

namespace ROBOTS
{

	public interface ICommand

	{
		void Execute();
		void Undo();
	}

	public class MakeStepCommand: ICommand
	{
		Robot robot;
		public MakeStepCommand(Robot robotSet)
		{robot = robotSet;}

		public void Execute()
		{ robot.StepForward(robot); }

		public void Undo()
		{ robot.StepBackwards(robot); }
	}

	public class BOXCommand : ICommand
	{
		Robot robot;


		public BOXCommand(Robot robotSet)
		{
			robot = robotSet;

		}

		public void Execute()
		{robot.pickUpBox(robot); }

		public void Undo()
		{robot.dropBox(robot);  }
	}


	public class NoCommand : ICommand
	{
		public void Execute()
		{
		}
		public void Undo()
		{
		}
	}


	public class MultiPult
	{
		ICommand[] buttons;
		Stack<ICommand> commandsHistory;

		public MultiPult()
		{
			buttons = new ICommand[2];
			for (int i = 0; i < buttons.Length; i++)
			{
				buttons[i] = new NoCommand();
			}
			commandsHistory = new Stack<ICommand>();
		}

		public void SetCommand(int number, ICommand com)
		{
			buttons[number] = com;
		}

		public void PressButton(int number)
		{
			buttons[number].Execute();

			commandsHistory.Push(buttons[number]);
		}
		public void PressUndoButton()
		{
			if (commandsHistory.Count > 0)
			{
				ICommand undoCommand = commandsHistory.Pop();
				undoCommand.Undo();
			}
		}
	}


}