using System;
using System.Linq;
using System.Collections.Generic;

namespace RockPaperScissorsPro
{
  public static class Round1Move
  {
    public static Move Rock { get { return new RockMove(); } }
    public static Move Scissors { get { return new ScissorsMove(); } }
    public static Move Paper { get { return new PaperMove(); } }

    public static Dictionary<string, Move> Moves = new Dictionary<string,Move>() {
        { "Rock", Round1Move.Rock },
        { "Scissors", Round1Move.Scissors },
        { "Paper", Round1Move.Paper }
    };
  }

  public abstract class Move
  {
    private string[] ValidMoves = new [] { 
      "RockMove", 
      "ScissorsMove", 
      "PaperMove", 
      "DynamiteMove", 
      "WaterBalloonMove" 
    };

    internal Move()
    {
    }

    public bool CanBeat(Move move)
    {
      if (!ValidMoves.Contains(GetType().Name))
        return false;

      if (!ValidMoves.Contains(move.GetType().Name))
        return true;

      return CanBeatLegalMove(move);
    }

    protected abstract bool CanBeatLegalMove(Move move);
  }
}