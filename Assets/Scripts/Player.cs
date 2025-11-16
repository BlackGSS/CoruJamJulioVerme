// ===================================================
// Author: Kadrius
// ===================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player
{
    public static float diggingStrength = 1f;
    public static int combatRound = 0;
    public static List<Accesories> Accesories = new();
    public static int currentScene = 0;
}

public enum Accesories { Camisa, Fachaleco };
