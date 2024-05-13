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

El control de la lógica difusa se hará en la clase FuzzyBrain. Su pseudocódigo es el siguiente:

```
class FuzzyBrain



function selectAction(Enemy enemy)



      fuzzyLogic.evaluate = true;
      nextAction = fuzzyLogic.GetFuzzificationByName("action");
      nextTarget = fuzzyLogic.GetFuzzificationByName("target");

```

 ## Agradecimientos

- [FuzzyLogic por chengkehan](https://github.com/chengkehan/FuzzyLogic)
- [Turn Based RPG por i-Jiro](https://github.com/i-Jiro/Unity3D-Turn_Based_RPG)
- [Standard Triplanar shader by Keijiro](https://github.com/keijiro/StandardTriplanar)
