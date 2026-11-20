¡Perfecto! Entonces vamos a cambiar el orden de trabajo. Me parece mejor que empiecen por el **mundo interno de las tiendas**, ya que tenés el fondo ilustrado y podemos construir el minijuego alrededor de él.

Vamos a trabajar primero con la habitación que me mostraste. No necesitamos todavía el escenario exterior ni el personaje caminando.

La idea es que esta escena sea el lugar donde se desarrolla el desafío de memoria de outfits.

# **Etapa 1. Crear el mundo interno en Unity**

[YOUTUBE INTROS — SOURVIOLET](https://images.openai.com/static-rsc-4/_TKAQFd12aj6_GtvYLZ_2qRmtFE6lj7mQ4XqwlnSwUszqDN0Ac0c8naEejRgGg6dlnK3e8wtL5gVEbFKqRSw7QaxAxTQpuPNqvrf7qZXgtcbwcDfwvB9fNboiNoZktKyvVkrTZYKWc9fGBsI6oUL_lcUuSwKcDKTc_n6YuJgaR0?purpose=inline)

[sourviolet.com](https://www.sourviolet.com/portfolio/youtubeintro?utm_source=chatgpt.com)

## **1. Crear una escena nueva**

En Unity:

1. Andá a `File > New Scene`.
2. Seleccioná una escena 2D.
3. Presioná `Create`.
4. Guardala con `Ctrl + Shift + S`.
5. Poné el nombre `MiniGameInterior`.

Guardala dentro de la carpeta `Scenes`.

Esta será la escena donde se desarrolla el minijuego dentro de la tienda.

## **2. Importar el fondo que ya tenés**

Ahora vamos a utilizar la ilustración de tu habitación.

1. Buscá la carpeta `Sprites` en `Project`.
2. Arrastrá tu imagen desde la computadora hasta esa carpeta.
3. Seleccioná la imagen.
4. En el Inspector, buscá `Texture Type`.
5. Seleccioná `Sprite (2D and UI)`.
6. Presioná `Apply`.

[Refabricating Animated Sprites in Unity using GIMP | by Brian David | Medium](https://images.openai.com/static-rsc-4/cKZULZp6ZQXY657oPTg3zVENre1ZP-0beqWbNd_7WqVH0MGmGcspu_cKLVx2ReOJtOye3z9EX7tbsIoj14K-U0op69Nx7tD20p9_350O9xegGQfhXHm7mCs3cbNB4KjxemQphDg8Z799c83QQ7i7KJfeDQt09Oi4_iONHF6Dq28?purpose=inline)

[medium.com](https://medium.com/%40Brian_David/refabricating-animated-sprites-in-unity-using-gimp-d197ccce1f2d?utm_source=chatgpt.com)

Después:

1. Arrastrá la imagen desde `Project` hasta `Scene`.
2. Cambiale el nombre al objeto a `RoomBackground`.
3. Comprobá que tenga el componente `Sprite Renderer`.

## **3. Ajustar el fondo a la cámara**

Este paso es importante porque antes vimos que tu habitación no ocupaba completamente el encuadre.

Seleccioná `Main Camera` en `Hierarchy`.

En el Inspector buscá:

- Projection: Orthographic.
- Position: X = 0, Y = 0, Z = -10.

Ahora abrí la pestaña `Game`.

En la parte superior, seleccioná una proporción de pantalla `16:9`.

[🔸 Phase 1: Setup and Basic Randomizations | Perception Package | 1.0.0-preview.1](https://images.openai.com/static-rsc-4/BS63bh6c7AsSR8Dw_YBSFBgx5iddt1lYgC7-F86BNcvmxWDWuAzUxnnCyj0h3ZGb5lLcYcYDgDxomUllUFWSsXVM8MHIQOs9rs45naAgGNPIPaTN1_GY3Xzvz5vryzgpfxIk0XW2NxIj0lfHS0SDXQDFOteEI3a-AprehIMUFRs?purpose=inline)

[docs.unity3d.com](https://docs.unity3d.com/Packages/com.unity.perception%401.0/manual/Tutorial/Phase1.html?utm_source=chatgpt.com)

**¿Cómo ajustar el tamaño?**

Seleccioná `Main Camera` y modificá `Size` en el componente Camera. Luego ajustá la escala del fondo hasta que ocupe todo el encuadre.

No estires el fondo de manera independiente en X e Y porque podrías deformar tu ilustración. Es mejor conservar sus proporciones y ajustar la cámara.

Guardá los cambios.

# **Etapa 2. Preparar los elementos del minijuego**

Ahora vamos a preparar la estructura de objetos que tendrá la escena.

Aunque todavía no tengamos todos los dibujos, podemos crear los contenedores y dejar los espacios preparados.

## **4. Crear el Canvas**

El Canvas es el espacio donde vamos a colocar los elementos de interfaz: temporizador, vidas, botones y opciones de ropa.

En `Hierarchy`:

1. Clic derecho.
2. Seleccioná `UI > Canvas`.
3. Cambiale el nombre a `GameCanvas`.

Seleccioná el Canvas y configurá:

| Propiedad            | Valor                  |
| -------------------- | ---------------------- |
| Render Mode          | Screen Space - Overlay |
| UI Scale Mode        | Scale With Screen Size |
| Reference Resolution | 1920 × 1080            |
| Match                | 0.5                    |

[mirror-networking.gitbook.io](https://mirror-networking.gitbook.io/docs/community-guides/unity-canvas-hud-guide?utm_source=chatgpt.com)

Unity también habrá creado un `EventSystem`. No lo elimines, porque lo vamos a necesitar para los botones.

## **5. Crear los paneles de la interfaz**

Dentro de `GameCanvas` vamos a crear varios objetos.

La estructura que te recomiendo es:

**Hierarchy**

&#x20;**GameCanvas**

**TopPanel**

Temporizador y vidas

**CharacterArea**

Lugar donde aparecerá la modelo

**ClothingPanel**

Opciones de prendas

**InstructionsPanel**

Instrucciones iniciales

**GameOverPanel**

Pantalla al perder

**ScorePanel**

Resultado final

Para crear cada uno:

1. Clic derecho sobre `GameCanvas`.
2. `UI > Panel`.
3. Cambiá su nombre.
4. Repetí el procedimiento.

Por ahora no hace falta que diseñes todos los paneles. Solo crealos y dejalos organizados.

**Importante:** no todos tienen que estar visibles al mismo tiempo. Por ejemplo, `InstructionsPanel` aparecerá al comienzo y `GameOverPanel` solamente cuando se pierdan las tres vidas.

## **6. Preparar el espacio de la modelo**

Ahora vamos a pensar en cómo se va a integrar el personaje con tu habitación.

[Play Blogger Dress Up Online for Free | Nub Games](https://images.openai.com/static-rsc-4/NrJDpbI3M5ef3_IOZZiquWxYKgevXmpepVN8aMmSHxKGpsdHhkbQiBjPJudLGaUFxt4w4qZnEnx-LWJ4PrkTjlvFIZYWjEI6QE0TnuwB2K3TkdVMWfZ_HkXP3cwLeOmcdhEPzs3ZVCbSejpqy8IwYKLy-xNWfbmJq-Dgn1O8Jn8?purpose=inline)

[nub.games](https://nub.games/games/blogger-dress-up-541842?utm_source=chatgpt.com)

La modelo debería ubicarse aproximadamente en el centro de la habitación, de manera que las prendas se puedan apreciar claramente.

Cuando tengas el dibujo:

1. Importalo como Sprite.
2. Arrastralo a la escena.
3. Cambiale el nombre a `CharacterModel`.
4. Ubicalo delante del fondo.
5. Ajustá su escala.

Las prendas van a ser imágenes independientes superpuestas al cuerpo de la modelo.

Por ejemplo:

```
CharacterModel
│
├── Hair
├── Shirt
├── Pants
├── Shoes
└── Accessories
```

No hace falta crear estos objetos todavía si no tenés los dibujos. Solo quiero que entiendas cómo vamos a organizarlo.

# **Etapa 3. Entender cómo funcionará el minijuego**

Una vez que tengamos los dibujos, vamos a programar esta secuencia:

FASE 1

**Memorizar el outfit**

[Fantasy Wardrobe Tales: Anime Dress-Up Simulation | Playgama](https://images.openai.com/static-rsc-4/vk6eVjFo2GARRTvy69dXDR_zng1G1Cp8on0OntJrABhvwN5l3oBq3Q_mzl0HBXj6OI7D46NM-o5UTKo9bWguB8ab9vrxz4a0Sjs4se6XaHj1XXLY1Z6uDOolNkuBM9GkvYNdiorKpgokw3wyVGJMnIzuKpwXaVCmSSrGQFjkyxs?purpose=inline)

[playgama.com](https://playgama.com/game/fantasy-wardrobe-tales?utm_source=chatgpt.com)

La modelo aparece vestida y tiene unos segundos para observar su conjunto.

FASE 2

**Seleccionar las prendas**

[Dress me up, darling by virxia](https://images.openai.com/static-rsc-4/GND3e0xisup3MVuHigUv6Q-JcJ4CXNXNDWnuJm90XjdNNFRW0UHqnSaT8o8_QVkq0xDiOAZldycWAnaYt0GBS6ZjE-_w_WuXxdwxml5ghA5LQhvos3BVtWkQNC67dDeYtyTc4X2VlrDmF5zyrO0ttsJgh4lZaCWo91Iur5fCphg?purpose=inline)

[virxia.itch.io](https://virxia.itch.io/dress-me-up-darling?utm_source=chatgpt.com)

El outfit desaparece y aparecen las opciones para reconstruirlo.

FASE 3

**Comprobar el resultado**

[\[策略模拟\] 超級女星：華麗怪誕城 Star Girl: Spooky Styles v3.13 修改版|破解版 - Android 遊戲.應用下載 -  冰楓論壇 - 綜合論壇.遊戲攻略.外掛下載.軟體下載.省錢優惠.星座運勢.手機APP](https://images.openai.com/static-rsc-4/1hGvogO0kNigDiP63qVbdULV7iNxY3U1O2h76G3Q0YanyusgdIL8FgV2-Wd2NL-IyRpbvXiYEzfu50epl5ujLDuQPVNHaZI3zb8RPkZwRuLBDO88fXSHKf7G0Zl4dXzmfSmltOHnuTm0PWXQugkWXzYxwDWg-M2_ecA7z8fCNJQ?purpose=inline)

[bingfong.com](https://bingfong.com/thread-476548-1-1.html?utm_source=chatgpt.com)

Se comprueba si las prendas seleccionadas coinciden con el outfit original y se actualizan las vidas y el puntaje.

Para eso, más adelante agregaremos estos scripts:

| Script           | Responsabilidad                 |
| ---------------- | ------------------------------- |
| GameManager      | Controlar las fases del juego.  |
| OutfitManager    | Guardar el outfit correcto.     |
| TimerManager     | Controlar el tiempo.            |
| ClothingSelector | Gestionar las prendas elegidas. |
| LivesManager     | Controlar las tres vidas.       |
| ScoreManager     | Calcular el puntaje.            |

# **10. ¿Qué deberías tener terminado por ahora?**

Antes de programar, quiero que consigas esta primera estructura:

**Lista de tareas — Primera escena**

Tareas completadas

**0/9**

Crear la escena MiniGameInterior.

Importar el fondo de la habitación.

Colocar RoomBackground en Scene.

Ajustar Main Camera a 16:9.

Comprobar que el fondo cubra toda la cámara.

Crear GameCanvas.

Configurar Canvas Scaler a 1920 × 1080.

Crear los seis paneles de interfaz.

Guardar la escena.

**Un consejo para tu proyecto:** no agregues todavía movimiento de personaje, tiendas ni colisiones. En esta escena la modelo estará quieta mientras realiza el desafío de memoria. Primero vamos a conseguir que el fondo y la interfaz funcionen correctamente.

## **¿Qué haremos después?**

Cuando termines esta primera parte, seguimos con la modelo y las prendas, y después empezamos a programar el sistema de memoria en C#.

**Cuando llegues a crear el Canvas, mandame una captura de cómo te quedó la ventana Hierarchy y el Inspector.** Así puedo indicarte exactamente qué modificar antes de avanzar al siguiente paso. 💗

🎮Continuar el proyecto Unity mañanaToca para configurar