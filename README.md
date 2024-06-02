# IAV-Proyecto Final: Sistema de Combate por Turnos

## Autores

* Daniel Alonso Herranz
* Javier Murillo González

## Propuesta

Este repositorio contiene el proyecto final para la asignatura de Inteligencia Artificial para Videojuegos de la UCM.

Este proyecto tiene como objetivo:

* Desarrollar una inteligencia artificial para enemigos de un sistema de combate por turnos, con una implementación basada en lógica difusa.
* Implementar dos enemigos distintos, cada uno con variables difusas distintas y comportamientos diferenciados, con reglas basadas en las variables.

## Punto de partida

Partimos de el repositiorio de [i-Jiro](https://github.com/i-Jiro), que ha desarrollado un sistema de combate por turnos basado en el ATC de FFV. Además, utilizaremos el paquete de lógica difusa de [chengkehan](https://github.com/chengkehan)

## Diseño de la solución

El cerebro base del enemigo procesará cada turno siguiendo estos pasos:

1. Recogerá y actualizará la información del combate
2. Calculará, en base a las variables obtenidas, las variables fuzzyficadas
3. Defuzzyficará las variables y determinará el comportamiento correspondiente a los resultados.
4. Realizará el comportamiento y esperará a su siguiente turno

Las variables que el enemigo tendrá a su disposición para fuzzyficar son:
* Puntos de vida actuales (de todos los combatientes)
* Puntos de maná actuales (de todos los combatientes)
* Los estados alterados todos los combatientes, tanto positivos como negativos
* La velocidad de los combatientes
* La defensa de todos los combatientes
* Las estadísticas de crítico (probabilidad y daño) de todos los combatientes

Los numeros no son representativos del producto final.

```
INPUT:
      HealthPoints:
            -healthy: 100~80
            -risky: 79~40
            -dangerous: 39~0

      ManaPoints:
            -max: 100~70
            -medium: 69~30
            -low: 29~1
            -out: 0

      StatusEffects:
            -lowRisk: 0~1
            -mediumRisk: 2~3
            -highRisk: x>3

      Speed:
            -fast: 100~70
            -normal: 69~40
            -slow: 39~1

      Defense: 
            -tank: 100~70
            -normal: 69~40
            -fragile: 39~1

      CriticalChance:
            -High: 100~50
            -Medium: 49~20
            -Low: x<20

      CriticalMultiplier:
            -High: 3~2
            -Medium: 2~1.5
            -Low: 1.5~1.25
```
Con estas fuzzificaciones haremos los comportamientos respecto al estado del juego que sacaran un output. Los numeros que saquen tendran que ser ajustados para cada IA.
```
OUTPUT:
      Attack:
            -high
            -medium
            -low
      Magic_Attack:
            -high
            -medium
            -low
      Defend:
            -high
            -medium
            -low
      Heal:
            -high
            -medium
            -low
```
Y las acciones se sacarian como tal:
```
IF myHealthPoints IS dangerous THEN Heal IS high
IF enemyHealthPoints IS risky AND CriticalChance IS High THEN Attack is high
```

El control de la lógica difusa se hará en la clase FuzzyBrain. Su pseudocódigo es el siguiente:
```
class FuzzyBrain



function selectAction(Enemy enemy)
      fuzzyLogic.evaluate = true;
      nextAction = fuzzyLogic.GetFuzzificationByName("action");
      nextTarget = fuzzyLogic.GetFuzzificationByName("target");

```
## Pruebas y métricas

Plan de pruebas para comprobar si un jugador nota la diferencia entre los distintos comportamientos de las IAs.

[Enlace al vídeo](https://www.youtube.com/watch?v=E-d9ewQuVac)

### Jugador contra IA
      -Se hara una partida en el que un jugador combatira contra una IA.
      -Se pondra al jugador contra IAs de distintos comportamientos.
      -Se hara el mismo input para comprobar que realiza las mismas acciones.  


## Producción

Enlace a la tabla de tareas de [Github Proyects](https://github.com/users/espiridifen/projects/3)

 ## Agradecimientos

- [FuzzyLogic por chengkehan](https://github.com/chengkehan/FuzzyLogic)
- [Turn Based RPG por i-Jiro](https://github.com/i-Jiro/Unity3D-Turn_Based_RPG)
- [Standard Triplanar shader by Keijiro](https://github.com/keijiro/StandardTriplanar)
