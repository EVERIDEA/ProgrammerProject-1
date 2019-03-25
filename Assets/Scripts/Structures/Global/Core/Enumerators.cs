using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerBehaviour
{
    IDLE,MOVE,JUMP,DUSH,ATTACK
}

public enum EnemyBehaviour
{
    IDLE,MOVE,JUMP,FLY,BLOCK_DAMAGE,ATTACK
}

public enum GameCondition
{
    PLAY,PAUSE,RESUME,SLOW_MOTION
}

public enum GamePhase
{
    MAIN_MENU, MAPS_MENU, INVENTORY_MENU, UPGRADE_CHAR_MENU
}

public enum Maps
{
    CENTRAL_CITY,SMALL_VILLAGE,DUNGEON,ARCANASMITH
}

public enum GamePlay
{
    QUEST,MAIN_GAME_PLAY
}

public enum DoorEvent
{
    TUTORIAL,FINISH
}