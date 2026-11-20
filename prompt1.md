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


¡¡¡Muy bien!!! 💗 Ahora sí tenemos una primera base visual del mundo interno. Ya podemos empezar a trabajar con lo más importante del videojuego: **el sistema de prendas y la reconstrucción del outfit**.

Te voy a recomendar una organización que les permita tener tanto el conjunto que la jugadora debe memorizar como las prendas aleatorias entre las que tendrá que elegir.

Primero, algo importante: no vamos a crear una escena diferente para cada outfit. Vamos a preparar un sistema reutilizable.

# **1. Organizar las carpetas de ropa**

Dentro de `Assets > Assets > Sprites`, vamos a crear una carpeta llamada `Clothes`.

Dentro de ella, organizaremos las prendas por categoría:

**Sprites**

**Clothes**

**Tops**

Remeras, blusas, tops

**Bottoms**

Pantalones, polleras, shorts

**Shoes**

Zapatos, botas, zapatillas

**Accessories**

Carteras, collares, accesorios

**Hair**

Peinados, si se pueden cambiar

¿Por qué recomiendo organizarlas así y no separar las carpetas entre ropa correcta y ropa aleatoria?

Porque una misma prenda puede ser la correcta en un desafío y aparecer como opción incorrecta en otro. No necesitamos duplicar las imágenes.

**La diferencia entre outfit correcto y ropa aleatoria la vamos a establecer mediante programación**, no duplicando los archivos.

# **2. Importar las prendas a Unity**

Cada prenda debe ser una imagen independiente.

Por ejemplo:

[Vectores de Woman crop top, imágenes vectoriales | DepositPhotos](https://images.openai.com/static-rsc-4/RbXXuCgUtsKJ45SuXOshDy30C2duXhFurqZkb2afjAt0__5TpuuSMZ-dYRvLlvoKLXlvmfIqA3_rJsSJO9HGzRjT_7WEoMpAFxQ7iJpBhpft66V_g1M1x4KRihOvQ6HpQrhNFT2sfR0UgUgGUoKBeh0mPb2oqjkqF0lxuwP4H7o?purpose=inline)

**Top rosa**

[Aesthetic pink mega , pink pleated skirt transparent background PNG clipart | HiClipart](https://images.openai.com/static-rsc-4/bRYWiM2AsAM1oiXq5ra2C8k9pfhW5QAntEq27mlIeqTWuun4CQxjhRYO8sLQREcJxukV3F3dKQ_qrN9QZBEifh9WQK9nZFvZWNG2uGCFyWZSpQOV-ZPEqZL-KXmtXxlCJm95XY60tWdjWGuXpl1sAlm2sKDoHRHXy59_8ZQim4Q?purpose=inline)

**Pollera rosa**

[【VRoid正式版】ロリータロングブーツ - クレイスSHOP - BOOTH](https://images.openai.com/static-rsc-4/DMMGiGAuem232aXJchV_yz4mXS2BHBdIcA7dRfBxspk8-efZJ9SJp49H_RUZn9gMwZX8Nre-8YbANitTzU_H47cfCjLb1IJoReCbv3rcgHby7QIilrHg8Xa3aihWWMWSylUys50NsURz_srdNu4xDAEvOiRbuPndj6GqgeTflBs?purpose=inline)

**Botas blancas**

[Girly Clipart Purse - Png Download (#2269231) - PinClipart](https://images.openai.com/static-rsc-4/rw06Nz6LJE0zUc_-Jp_7ABkIFgSlSYMHHRi5F6dEDggVuQu5-8Rad_0MbZNRftSdbNA6uuHB-CrucStgos76S6L_sdriVFnlBYyjyRjuwMv_VdPojNYL08Bcq3s8Zr3w3ZbdYwIklzyNZ7pRdGOyo-NctYyDPSf46P7wexi01n4?purpose=inline)

**Cartera rosa**

Para importarlas:

1. Arrastrá las imágenes a sus respectivas carpetas.
2. Seleccioná cada imagen.
3. Configurá `Texture Type: Sprite (2D and UI)`.
4. `Sprite Mode: Single`.
5. `Compression: None`.
6. Presioná `Apply`.

**Importante:** usen PNG con fondo transparente. Así las prendas podrán superponerse al cuerpo de la modelo sin tapar el resto de la imagen.

# **3. Diferenciar el outfit que debe memorizar de las prendas aleatorias**

Esta es la parte central del minijuego.

Vamos a tener dos conjuntos de información:

OUTFIT OBJETIVO

**El conjunto que la jugadora debe memorizar.**

[Gacha Life Girl Outfits Pink at Taylah North blog](https://images.openai.com/static-rsc-4/bnSGLBLqwiM7OHSAjqfDPuTuWD4yeedvI8PbD0N9dFM5As21GL6QrXjTtpBfXuOF8deeoN4gCNnIdzW3Fs-OLPEF6lqGTON6ThIqN7TtceLuOzD255KNQYZrKNLzoRtblmX5p4EDLpgHm9V51BXtb3rw_07OdfrL4FB8eG83NxA?purpose=inline)

[storage.googleapis.com](https://storage.googleapis.com/dokywfpouoidje/gacha-life-girl-outfits-pink.html?utm_source=chatgpt.com)

Por ejemplo:

- Top rosa.
- Pollera rosa.
- Botas blancas.
- Cartera rosa.

OPCIONES ALEATORIAS

**Las prendas entre las que debe elegir.**

[This item is unavailable - Etsy](https://images.openai.com/static-rsc-4/IDmgogEWcaJYfdzB1iW8wAoFrYinwks4f5rJKhQxM3p0kL6VpX4U_qoWs0nl7wJBjTbZ-x-2C2PG0PyBEJBhoFjJtKmH4kIFzMFVRtK_ZLp2-1sDkPWy5WJHy9VNV4NyLeQtRhnl7s8ILnnOl5MnHWZkaXaGu__agSLiixIQHTs?purpose=inline)

[skirt fashion set cartoon vector illustration](https://images.openai.com/static-rsc-4/D7TimCeSa3kxiANMJwOPYASV-642slvYT21Ez_1zYBx0mzQ5SPhLIev4a4uV3eBWoKSPx5HxGJGVCHn8z_Hl4ebrDWKO5F_hq84cheVAj1zm9aW3FTzi_hE54gc0v35RvhiZCEV7DrUn39v5tS27flho9TcFsbIhJlPxppdytaxnwmbSXcl-LMgP155eTg2S?purpose=inline)

[frankenstyle! by kindanice, grass_fed_fish, lilac ♡ for 🌸 Girly Game Jam #2 🌸 - itch.io](https://images.openai.com/static-rsc-4/GqBAk5VwAw_NzcOieh6HKyn8nzi1hbV9DHXhPgVnclHUE6qMu867R8NUqncYFoSgKDgcAyXPWLZjpox94yOT6r070VvZp6mR1VTiAFWjenSqrNSkaYNFk731i9asuiJ3Wsia8XWMzdAWdC-AlZ6K7XDm6otNSCErebydfUd1kw0?purpose=inline)

10

Por ejemplo:

- Tres tops diferentes.
- Tres polleras diferentes.
- Tres pares de zapatos.
- Tres accesorios.

El funcionamiento sería:

1. El juego selecciona un outfit objetivo.
2. La modelo aparece vestida con esas prendas.
3. La jugadora memoriza el conjunto.
4. El outfit desaparece.
5. Aparecen las opciones aleatorias.
6. La jugadora debe elegir las prendas que recuerda.
7. Unity compara las elecciones con el outfit objetivo.

Por ejemplo, si el outfit correcto tiene el top rosa, pero la jugadora selecciona el top azul, se registra un error y pierde una vida.

# **4. Cómo vamos a colocar las prendas sobre la modelo**

Acá hay algo importante que debemos preparar correctamente.

No vamos a colocar las prendas como imágenes sueltas al azar. Cada una debe tener una posición específica sobre el cuerpo de la modelo.

La estructura que queremos conseguir es:

**CharacterModel**

**Body**

Hair

Top

Bottom

Shoes

Accessories

Cada prenda tendrá su propio `Sprite Renderer`.

Así, cuando el juego cambie de outfit, podrá reemplazar la imagen del Top sin modificar el cuerpo, los zapatos ni los accesorios.

**Pero atención:** para hacer esto correctamente, necesitamos que el dibujo base de la modelo tenga el cuerpo sin las prendas que queremos cambiar. Si la modelo tiene la ropa dibujada directamente en su imagen, primero tendremos que preparar una versión base.

# **5. ¿Dónde aparecerán las opciones de ropa?**

Las prendas seleccionables no estarán colocadas directamente en el mundo como objetos Sprite normales.

Van a estar dentro del `ClothingPanel` que ya creaste en el Canvas.

La organización será:

**GameCanvas**

**TopPanel**

Vidas y temporizador

**CharacterArea**

Modelo y outfit

**ClothingPanel**

Matriz de prendas seleccionables

Dentro de `ClothingPanel` vamos a utilizar un `Grid Layout Group`, que permite organizar automáticamente las prendas en filas y columnas.

Cada prenda será un botón con una imagen (`Image`).

Por ejemplo, si tenemos cuatro categorías con tres opciones cada una, tendremos doce opciones para seleccionar.

Todavía no crees los botones: primero necesitamos importar y preparar los dibujos.

# **6. ¿Qué hacemos ahora?**

Por el momento, quiero que avancemos en este orden:

1. Crear la carpeta `Clothes`.
2. Crear las subcarpetas de categorías.
3. Importar todas las prendas como Sprite.
4. No arrastrarlas todavía a la escena.
5. Preparar la imagen base de la modelo.

Después vamos a crear el primer outfit y comprobar que podemos cambiarle las prendas desde Unity.

## **Necesito confirmar algo antes de seguir**

En la captura veo que la modelo ya tiene un top rosa, una pollera y botas.

**¿Tenés el dibujo de la modelo sin ropa (solamente el cuerpo), o solamente tenés la modelo ya vestida?**

Esto es fundamental porque, si queremos cambiarle la ropa mediante código, necesitamos separar el cuerpo de las prendas. Así evitamos tener que dibujar una modelo diferente para cada outfit.

Mi recomendación es que primero consigamos que funcione un solo outfit completo y después incorporemos las opciones aleatorias. 💗

¡Perfecto! 💗 Ahora vamos a empezar a construir el sistema de vestimenta. Esta es una de las partes más importantes del videojuego, porque necesitamos que la modelo pueda cambiar de ropa sin tener que reemplazar su imagen completa.

Te voy a explicar paso a paso dónde hacer clic, qué objetos crear y cómo organizarlos en Unity 6.

**Nuestro primer objetivo será conseguir que la modelo tenga el cuerpo, el cabello, el top, la pollera y los zapatos como elementos independientes.** Después vamos a programar el cambio de prendas.

# **ETAPA 1. Preparar la estructura de CharacterModel**

## **Paso 1. Crear un objeto vacío**

Primero vamos a crear el objeto principal que contendrá todas las partes de la modelo.

1. Andá a `Hierarchy`.
2. Hacé clic derecho en un espacio vacío.
3. Seleccioná `Create Empty`.
4. Cambiale el nombre a `CharacterModel`.

[Lesson 5.1 - Clicky Mouse - Unity Learn](https://images.openai.com/static-rsc-4/TDNv2THRRDLovKdJasUl2ofREUKtaSXM6LS7oA8g2WkhwHjMlB1tsdLA6WLE_D4WI7WhtfFDjygtgoURN2sV6JESUw0oZG5lXPZM8kr1XJT6HrtWLGHRapY5RyFnvEs-o0d9fS99wouo7BvVlOq26u5f7-Gig6tiGEzDz_B6uvw?purpose=inline)

[learn.unity.com](https://learn.unity.com/pathway/junior-programmer/unit/user-interface/tutorial/lesson-5-1-clicky-mouse-1?version=2022.3\&utm_source=chatgpt.com)

Este objeto no tendrá ninguna imagen. Solamente funcionará como contenedor de las partes del personaje.

## **Paso 2. Crear los elementos que estarán dentro de CharacterModel**

Ahora vamos a crear los objetos hijos.

1. Hacé clic derecho sobre `CharacterModel`.
2. Seleccioná `Create Empty`.
3. Cambiale el nombre a `Body`.
4. Repetí el procedimiento para crear los siguientes objetos:

- Hair
- Top
- Bottom
- Shoes
- Accessories

Tu Hierarchy debería quedar así:

**CharacterModel**

Body

Hair

Top

Bottom

Shoes

Accessories

¡Listo! Ya tenemos la estructura, pero todavía no se ven las imágenes.

# **ETAPA 2. Colocar las imágenes de la modelo**

Acá tenemos que diferenciar algo importante:

- Los objetos que acabamos de crear son contenedores.
- Las imágenes que importaron son los dibujos que vamos a mostrar.

Para que cada parte se vea, necesitamos agregarle un componente `Sprite Renderer`.

## **Paso 3. Colocar el cuerpo**

Primero necesitamos una imagen de la modelo sin ropa, es decir, el cuerpo base.

Si todavía no tienen ese dibujo, deben prepararlo en Illustrator o Photoshop. La imagen actual de la modelo ya vestida no se puede separar automáticamente en cuerpo, cabello y ropa simplemente creando objetos en Unity.

Cuando tengan el cuerpo:

1. Importen el PNG a `Sprites`.
2. Seleccionen el objeto `Body` en Hierarchy.
3. En Inspector, presionen `Add Component`.
4. Busquen `Sprite Renderer`.
5. Agréguenlo.
6. Arrastren la imagen del cuerpo al campo `Sprite`.

[SpriteRenderer - Order in Layerの値は-32768-32767(Unity 2021.3.1f1) - より良いエンジニアを目指して](https://images.openai.com/static-rsc-4/Wy7AFuNG2OjL4Y7DENMXSsG299ifDQMPQxLGnaoVkmU9S5qwonogRldRnxrkTj9_N48RjdWKYM4eypq0B9khVPQL9e1xfnWwCI-rBbrX-TKYJgqvZPkWFw2aKbtb3F95SuupGe9yiWr92lx81Dr1QjTigw5XMEpPSs99Sbe8_CI?purpose=inline)

[rimever.hatenablog.com](https://rimever.hatenablog.com/entry/2022/05/25/000000?utm_source=chatgpt.com)

Ahora deberían visualizar el cuerpo en la escena.

## **Paso 4. Colocar el cabello**

Repetimos el procedimiento:

1. Seleccioná `Hair`.
2. `Add Component`.
3. Buscá `Sprite Renderer`.
4. Arrastrá la imagen del cabello al campo `Sprite`.

Hacé lo mismo con `Top`, `Bottom`, `Shoes` y `Accessories`, cuando tengan los dibujos correspondientes.

**Importante:** cada imagen debe tener fondo transparente (PNG).

# **ETAPA 3. Alinear las prendas con el cuerpo**

Esta parte es fundamental para que no parezca que las prendas están flotando.

[Rig-Ready Character Layers | AI Layer Prep for Live2D & Spine | Image to Layers](https://images.openai.com/static-rsc-4/n0mj9FTTJOYteWpWcXwCT2nutDoh0MoeSBronrm0nmlzl2Gb1elqz64Nr-H4JvHxpOp11tKvzx2RKwvFV0gZsyyyJJHiPT3o8ZhjWRAXmYpvLFD30DXR6V-PsHqqzXt2_MabI9ubPjCgxOJrkuPWVwn-G32ZV69cksQ5bCksnWY?purpose=inline)

[imagetolayers.com](https://www.imagetolayers.com/solutions/rig-ready-character-layers?utm_source=chatgpt.com)

## **Paso 5. Ajustar las posiciones**

Seleccioná cada objeto hijo y revisá su `Transform`.

Si prepararon todos los dibujos utilizando el mismo tamaño de lienzo y manteniendo la misma posición de la modelo, pueden comenzar con estos valores:

| Propiedad  | Valor |
| ---------- | ----- |
| Position X | 0     |
| Position Y | 0     |
| Position Z | 0     |
| Scale X    | 1     |
| Scale Y    | 1     |

Esto sirve para alinear las imágenes que tienen exactamente la misma referencia y dimensiones.

Si las prendas fueron exportadas como imágenes recortadas individualmente, tendrán que acomodar sus posiciones manualmente.

## **Paso 6. Configurar el orden de las imágenes**

Queremos que el cabello, la ropa y los accesorios se vean correctamente superpuestos.

En cada `Sprite Renderer`, buscá `Order in Layer`.

Podés comenzar con esta organización:

| Objeto      | Order in Layer |
| ----------- | -------------- |
| Body        | 0              |
| Bottom      | 1              |
| Shoes       | 2              |
| Top         | 3              |
| Hair        | 4              |
| Accessories | 5              |

Estos valores son orientativos: dependiendo de cómo estén dibujadas las prendas, algunas partes deberán quedar delante o detrás de otras.

Por ejemplo, si el cabello tiene mechones que pasan por delante del top, necesitaremos separar esos mechones en otra capa.

# **ETAPA 4. Preparar el sistema de selección de prendas**

Ahora viene una distinción MUY importante para el funcionamiento del videojuego.

No vamos a colocar todas las prendas dentro de `CharacterModel`.

Vamos a tener dos grupos:

**1. Modelo vestida**

[Barbie Stickee Style flat dolls with Reusable Sticker Clothing - YouLoveIt.com](https://images.openai.com/static-rsc-4/UnaJI8uDJETJUE-aanZfgy8ozU4lPhIU0DSuh1w8feI7N7LrGBlxiQJ5BcBR_NxdY8VtcHoZDinEQRD7q20YQQFBx4yANsGqwQN0wv53a5dVciKNAy9p74t-P3yp-vZp73yITNgnlVl3uXs9n016YyU9depbzBFkiSpHRCm0wkc?purpose=inline)

[youloveit.com](https://www.youloveit.com/dolls/4951-barbie-stickee-style-dolls.html?utm_source=chatgpt.com)

Aquí van únicamente las prendas que lleva puestas la modelo.

**2. Matriz de selección**

[Idol Livestream: Doll Dress Up](https://images.openai.com/static-rsc-4/JKWZFgMmOaVDTiYJ07px9dDZ3NM8tD5YstVhMpaUKeQTGFDoa-NbMUlKE-5i4GwmQrK32JOd_Yg12vHmPTvDmgdE1LuaKFTsIaVcthiLQs63OxnjGJAPlCYdUASseRzBvliyG6hj3UytfxeRavKynj_goL49omMjAKjCSTMwkWg?purpose=inline)

[fnf-games.io](https://fnf-games.io/idol-livestream-doll-dress-up?utm_source=chatgpt.com)

Aquí van todas las opciones de ropa, tanto las correctas como las aleatorias.

## **Paso 7. Preparar ClothingPanel**

En Hierarchy:

1. Desplegá `GameCanvas`.
2. Seleccioná `ClothingPanel`.
3. Dentro de él, creá un objeto UI vacío llamado `ClothingGrid`.
4. Seleccioná `ClothingGrid`.
5. Presioná `Add Component`.
6. Buscá `Grid Layout Group`.

Este componente organizará automáticamente las opciones de ropa en una cuadrícula.

[Grouping and Layout Techniques for UI Components - Unity Learn](https://images.openai.com/static-rsc-4/GjXJseOCbG58jcN7k-yfRasy_tyNFFJNu1kteqezTF_aWgEVNpra4i98YeiPWLxMxI60YuBTv_Jux0HWBg6zHsQxEQRXlKBu3VJg_goCcwflFCf6TE35UoeRDBcaum3x1R3C5qLd2ARhEWJ2P9PjbegJTiY_Zj_Y2_tx4n5ntVY?purpose=inline)

[learn.unity.com](https://learn.unity.com/tutorial/grouping-and-layout-techniques-for-ui-components-2019-3?version=2019.4\&utm_source=chatgpt.com)

Todavía no agreguen las prendas como botones. Primero vamos a comprobar que la modelo pueda cambiar su ropa.

# **ETAPA 5. La primera prueba que vamos a realizar**

Antes de programar el minijuego completo, quiero que hagamos una prueba sencilla:

Primera prueba funcional

**Cambiar el top de la modelo.**

[Cartoon Bratz Characters PNG 52 PNG Image](https://images.openai.com/static-rsc-4/3nuivEcBXA1EPadabXsn6JQrY5ApmgigA9M6hFvnG_j3MU3ci49M_3WD1XF-JpGMOSjE5YlTZXyxTMZ2o7GeujDdQmkScjNoNPi6bm1XPj4e4VDoQkPL_Xawq9awNQVTkoQzI1NWeEiQmkn_KcdFqH96Tr_wfDuXvGCiCLzTaRM?purpose=inline)

Top rosa

[Mame Riot【キプフェル・リルレオ】 - かわいい服売ってるよ - BOOTH](https://images.openai.com/static-rsc-4/p_YAWPIlnwnlhhVAAEWNJHcxsq83DBr-9PXOHeKaODPRiUof02l8_B_UO5RjpG9yeFUNUzODwPHeeQcDYh7sb7bPnhW0IjT8jlLBUeImiNwH3wDvBKYyLrctIL9U72flij_dIUTsSpy1ykTtw8Qjj7wa20sAB4q5w3uWM2nzJGQ?purpose=inline)

Top violeta

Queremos que al seleccionar el segundo top, la modelo cambie su prenda sin modificar el resto de su apariencia.

Para conseguirlo, después vamos a crear un script llamado `ClothingSelector`, que cambiará el Sprite del objeto `Top`.

# **Antes de continuar, necesito que revisemos algo**

Hay una cuestión que puede cambiar bastante los pasos siguientes.

En tu captura anterior, la modelo ya aparecía vestida con un top, una pollera y botas.

**¿Cómo tienen preparados los dibujos de las prendas?**

**1. ¿Tienen el cuerpo de la modelo sin ropa?**

Sí, tenemos el cuerpo por separado.

No, solamente tenemos la modelo ya vestida.

Todavía lo estamos preparando.

**2. ¿Cómo están exportadas las prendas?**

Cada prenda es un PNG independiente con fondo transparente.

Son imágenes independientes, pero tienen fondo blanco.

Tenemos varias prendas juntas en una sola imagen.

Enviar respuestas

Te pregunto porque no quiero que pierdan tiempo creando objetos en Unity que después no puedan utilizar correctamente. Primero tenemos que conseguir que las capas de la modelo funcionen y luego pasamos al sistema de outfits y prendas aleatorias. 💗

AAAAH, ¡AHORA SÍ! JAJA. 😭💗 Perdón, había interpretado que tenían el cuerpo completamente separado de la ropa interior.

Entonces, **la modelo que ya tienen en Unity, con su ropa interior, ES el cuerpo base que vamos a utilizar.** ¡No necesitan dibujar otro cuerpo!

Vamos a trabajar a partir de esa imagen.

## **1. Cómo vamos a organizar la modelo**

La imagen que ya tienen contiene el cuerpo, la ropa interior y posiblemente el cabello.

Vamos a aprovecharla como base y superponer las prendas que importaron.

La estructura será:

**CharacterModel**

**Body**

La modelo actual con ropa interior

**Top**

Remeras, blusas y tops

**Bottom**

Polleras, pantalones y shorts

**Shoes**

Calzado

**Accessories**

Carteras y accesorios

**Hair**

Cabello, si luego quieren cambiarlo

Por ahora el cabello puede quedarse dentro de `Body` si forma parte de la imagen original. No hace falta separarlo.

## **2. Qué tienen que hacer ahora en Unity**

Vamos a modificar la estructura que ya tienen, sin borrar la modelo.

**Paso 1.** En Hierarchy, seleccioná el objeto que contiene actualmente la imagen de la modelo (`lachiquita@3x_0`, según tu captura).

**Paso 2.** Cambiale el nombre a `Body`.

**Paso 3.** Creá un objeto vacío:

- Clic derecho en Hierarchy.
- `Create Empty`.
- Nombre: `CharacterModel`.

**Paso 4.** Arrastrá `Body` encima de `CharacterModel` para convertirlo en hijo.

**Paso 5.** Creá dentro de `CharacterModel` otros objetos vacíos:

- `Top`
- `Bottom`
- `Shoes`
- `Accessories`

No agregues todavía otro Sprite Renderer a esos objetos. Primero vamos a preparar su estructura.

## **3. ¿Cómo funcionará cuando le pongamos ropa?**

Por ejemplo:

Modelo base

[Fashion Magnetic Dress up Doll & Outfit | Fun Kids Gift - Etsy](https://images.openai.com/static-rsc-4/EvQLE6swbjiqQY3ZGTgsFGojFIIBjQnuXX7s_nh7BZOcGMKEP9w9WLjst7yxj-mKVm4KxijsJGdgxX338C4aUH0BTPB1CPLVpSv7rZs2-x2Tn3ziRPwFT-D6bV1BwaLew6GYpZz0VF6vdr-I2ZBlyaokzMyDLv2noxmgM90N2F8?purpose=inline)

Prendas superpuestas

[【Free/無料】Simple Balletcore【MameFriends】 - Rimeo Shop - BOOTH](https://images.openai.com/static-rsc-4/l3rqy6TvbsCd_brIEidIvuhuCszfRdA_XQn3bl5S4vxAmbS5QWDzi-oWcffeXtINgqR0ckHjuEpCMZx3lOk11rm2nfesQQpct-hLavHPBa7vTGzSBCRf2OyHY6XjExPlRGFH5bU-MKKSK994KucmNeevYRmZYx0kzVbDR1_lcfw?purpose=inline)

La ropa interior seguirá estando en la imagen base, pero quedará cubierta por las prendas que coloquemos encima.

Por ejemplo, cuando seleccionemos un top:

- Unity cambiará el Sprite del objeto `Top`.
- El cuerpo permanecerá igual.
- La pollera y los zapatos no cambiarán.

## **4. Antes de seguir, quiero que hagamos una prueba**

Primero vamos a conseguir que una sola prenda aparezca correctamente sobre la modelo.

**Necesito que me confirmes algo: ¿las prendas que dibujaron tienen exactamente el mismo tamaño de lienzo y la misma posición que la modelo base, o son PNG recortados individualmente?**

Esto es muy importante porque determina cómo vamos a alinearlas para que encajen perfectamente en el cuerpo, sin tener que acomodar cada prenda a ojo. 💗

¡Perfecto! Entonces simplificamos la estructura. No vamos a utilizar pelo ni accesorios, solamente **BODY, TOP, BOTTOM y SHOES**.

Y quiero aclararte algo que puede estar generando la confusión: hay dos lugares diferentes en Unity.

- **Project > Assets > Sprites:** donde guardan las imágenes.
- **Hierarchy:** donde crean y organizan los objetos que aparecen en el videojuego.

El `CharacterModel` que tienen guardado como imagen en `Sprites` es un archivo gráfico. Nosotros necesitamos crear otro objeto llamado `CharacterModel` en la Hierarchy para organizar las prendas.

Vamos paso a paso.

# **1. Crear el contenedor CharacterModel**

En la ventana `Hierarchy`:

1. Hacé clic derecho en un espacio vacío.
2. Seleccioná `Create Empty`.
3. Cambiale el nombre a `CharacterModel`.
4. En el Inspector, dejá su posición en X = 0, Y = 0, Z = 0.

[Lesson 5.1 - Clicky Mouse - Unity Learn](https://images.openai.com/static-rsc-4/TDNv2THRRDLovKdJasUl2ofREUKtaSXM6LS7oA8g2WkhwHjMlB1tsdLA6WLE_D4WI7WhtfFDjygtgoURN2sV6JESUw0oZG5lXPZM8kr1XJT6HrtWLGHRapY5RyFnvEs-o0d9fS99wouo7BvVlOq26u5f7-Gig6tiGEzDz_B6uvw?purpose=inline)

[learn.unity.com](https://learn.unity.com/pathway/junior-programmer/unit/user-interface/tutorial/lesson-5-1-clicky-mouse-1?version=2022.3\&utm_source=chatgpt.com)

Este objeto será el padre de todas las partes de la modelo.

# **2. Colocar el BODY dentro de CharacterModel**

En tu captura anterior, la modelo aparecía como `lachiquita@3x_0` en Hierarchy.

Ese es el objeto que vamos a utilizar como cuerpo base.

1. Buscá `lachiquita@3x_0` en Hierarchy.
2. Arrastralo encima de `CharacterModel`.
3. Ahora debería aparecer indentado debajo de CharacterModel.
4. Seleccionalo y cambiale el nombre a `Body`.

¡Ya tenemos el cuerpo!

# **3. Crear los tres objetos de ropa**

Ahora vamos a crear los espacios donde aparecerán las prendas.

Hacé clic derecho sobre `CharacterModel` y seleccioná `Create Empty`.

Creá estos tres objetos:

- `Top`
- `Bottom`
- `Shoes`

Tu Hierarchy debería quedar así:

**CharacterModel**

**Body**\


Ya tiene imagen



**Top**\


**Bottom**\


**Shoes**\


Por ahora `Top`, `Bottom` y `Shoes` estarán vacíos. Es correcto.

# **4. Colocar las imágenes de las prendas**

Ahora vamos a conectar los dibujos que ya tienen importados.

Por ejemplo, supongamos que tienen un top rosa.

1. Seleccioná el objeto `Top` en Hierarchy.
2. En Inspector, presioná `Add Component`.
3. Buscá `Sprite Renderer`.
4. Agregalo.
5. En el campo `Sprite`, arrastrá el dibujo del top rosa desde `Project`.

[Lesson 3.1 - Jump Force  - Unity Learn](https://images.openai.com/static-rsc-4/RcJNLJW__J9aRI0cloJynfslKTVWqeOeHuon-JuVgK7odSTE_s2kg2A-fgOvnBJ5V_enLaKGAE7Us3LtVNAEpz-WacH09MdrynRSHo3eqoyhBL_lAqVcqXrOWx0V37KnEUjIN9LIzfJ3ezpRVlS7LWFmt950k6wgc_JzfUNio6g?purpose=inline)

[learn.unity.com](https://learn.unity.com/pathway/junior-programmer/unit/sound-and-effects/tutorial/lesson-3-1-jump-force-2?version=6.0\&utm_source=chatgpt.com)

Repetí el procedimiento para `Bottom` y `Shoes`.

**Importante:** todavía no estamos programando el cambio de prendas. Estamos preparando los objetos que después recibirán las imágenes correspondientes.

# **5. Alinear las prendas con la modelo**

Para que las prendas coincidan con el cuerpo:

- Si los PNG tienen el mismo tamaño de lienzo y la misma posición que la modelo, dejá sus posiciones locales en X = 0 e Y = 0.
- Si están recortados individualmente, tendremos que acomodarlos manualmente.

En los Sprite Renderer también configurá el orden de dibujo:

| Objeto | Order in Layer |
| ------ | -------------- |
| Body   | 0              |
| Bottom | 1              |
| Shoes  | 2              |
| Top    | 3              |

Estos valores son iniciales. Puede que debamos modificarlos según cómo se superpongan las prendas.

# **6. ¿Cómo debería quedar todo organizado?**

[Swapping individual Sprites | 2D Animation | 9.0.4](https://images.openai.com/static-rsc-4/5cRRoZb1oJOMywvWLntVmjcr0BwDD7ZfxA2CPyizh6Iz8rm68hfBv_CPt2eqF1M6jFuB7DX-h03DT6ytxL_oafauPhwp1-dbwR-u02AK6Ja1DMzzKFWlg0K7twW-R0-etTxMqFjk8IWGy4QSsQr7DD4SPtdQNSrcMO2FUDN8GzE?purpose=inline)

[docs.unity3d.com](https://docs.unity3d.com/Packages/com.unity.2d.animation%409.0/manual/CharacterParts.html?utm_source=chatgpt.com)

La estructura final será:

```
Hierarchy
│
├── Main Camera
├── RoomBackground
│
├── CharacterModel
│   ├── Body
│   ├── Top
│   ├── Bottom
│   └── Shoes
│
├── GameCanvas
│   ├── TopPanel
│   ├── CharacterArea
│   └── ClothingPanel
│
└── EventSystem
```

# **7. ¿Qué haremos después?**

Una vez que consigamos visualizar correctamente las tres prendas sobre la modelo, vamos a programar el sistema para que:

1. Se muestre un outfit completo.
2. La jugadora lo memorice.
3. Se oculten las prendas.
4. Aparezcan las opciones aleatorias en `ClothingPanel`.
5. La jugadora seleccione el top, bottom y shoes correctos.

Nuestro próximo objetivo

**Conseguir que la modelo pueda cambiar su top sin que cambien las otras prendas.**

Una cosa que quiero que hagas antes de avanzar: creá `CharacterModel` en Hierarchy, colocá adentro `Body`, `Top`, `Bottom` y `Shoes`, y mandame una captura.

Así verificamos que la estructura esté bien antes de empezar a conectar los dibujos. 💗

¡¡¡GENIAL!!! 💗 Ahora que ya tienen el fondo, la modelo y las ocho prendas organizadas, vamos a empezar a darle funcionalidad al videojuego.

A partir de ahora vamos a trabajar en Unity y C#. No vamos a agregar todo de golpe: primero conseguiremos que la modelo pueda cambiar de ropa y después conectaremos eso con el minijuego de memoria.

# **ETAPA 1. Comprobar que las prendas estén bien colocadas**

Antes de programar, tenemos que asegurarnos de que las prendas coincidan con el cuerpo.

## **Paso 1. Seleccionar una prenda**

En `Hierarchy`:

1. Desplegá `CharacterModel`.
2. Desplegá `Top`.
3. Seleccioná `Top1`.
4. Comprobá que tenga asignado su Sprite Renderer y su imagen.

## **Paso 2. Alinear la prenda con la modelo**

En el Inspector, revisá `Transform`.

Si las imágenes se exportaron con el mismo tamaño de lienzo y la misma posición que el cuerpo:

- Position X: 0
- Position Y: 0
- Position Z: 0
- Scale X: 1
- Scale Y: 1

Si son imágenes recortadas individualmente, ajustá su posición y escala hasta que coincidan con el cuerpo.

Repetí con los otros tops, bottoms y shoes.

## **Paso 3. Comprobar el orden de las capas**

En cada `Sprite Renderer`, configurá inicialmente:

| Elemento | Order in Layer |
| -------- | -------------- |
| Body     | 0              |
| Bottom   | 1              |
| Shoes    | 2              |
| Top      | 3              |

Si alguna prenda queda detrás de otra incorrectamente, modificaremos esos valores.

## **Paso 4. Dejar solamente una prenda visible por categoría**

Por ahora queremos que la modelo tenga un solo top, un solo bottom y un solo par de zapatos.

En Hierarchy, seleccioná los objetos que no quieras mostrar y desactivá el checkbox que aparece junto a su nombre.

Por ejemplo:

- Top1: activo.
- Top2: inactivo.
- Top3: inactivo.
- Bottom1: activo.
- Bottom2: inactivo.
- Bottom3: inactivo.
- Shoes1: activo.
- Shoes2: inactivo.

[Live2D + Unity 开发日记 1\~\_unity live2d-CSDN博客](https://images.openai.com/static-rsc-4/xntjt_tS-Gt-JH0OxpZHpUEqpSF_pkGxgxvbSyxpz6iIvBLr1KCG_7uf5B0BwfFSD5MXwL9UNJYACLQNRwaTkI9VgTBhiRq320I6Dh2H4XCWVf7iVZt586EE-LLMEH6znbuC6UEj9VLIpbfDg3XrNE38eDuhyLOh1rGgHJydZG0?purpose=inline)

[blog.csdn.net](https://blog.csdn.net/weixin_62373966/article/details/130595991?utm_source=chatgpt.com)



Objetivo de esta etapa

&#x20;La modelo debe verse con un outfit completo, sin prendas superpuestas incorrectamente.



# **ETAPA 2. Programar el cambio de prendas**

Ahora vamos a conseguir que, cuando seleccionemos una opción, la modelo cambie su ropa.

Para esto vamos a crear una clase llamada `ClothingManager`.

## **Paso 5. Crear un GameObject para controlar la ropa**

En `Hierarchy`:

1. Clic derecho en un espacio vacío.
2. Seleccioná `Create Empty`.
3. Nombralo `ClothingManager`.

Este objeto no tendrá ninguna imagen. Su función será controlar qué prendas aparecen y cuáles desaparecen.

## **Paso 6. Crear el script ClothingManager**

1. Entrá en `Assets > Scripts`.
2. Clic derecho.
3. Seleccioná `Create > C# Script`.
4. Nombralo exactamente `ClothingManager`.
5. Abrilo con Visual Studio.

Pegá este código:

```

using UnityEngine;

public class ClothingManager : MonoBehaviour
{
    [Header("Tops")]
    public GameObject[] tops;

    [Header("Bottoms")]
    public GameObject[] bottoms;

    [Header("Shoes")]
    public GameObject[] shoes;

    public void SelectTop(int index)
    {
        ChangeClothing(tops, index);
    }

    public void SelectBottom(int index)
    {
        ChangeClothing(bottoms, index);
    }

    public void SelectShoes(int index)
    {
        ChangeClothing(shoes, index);
    }

    private void ChangeClothing(GameObject[] clothes, int index)
    {
        if (index < 0 || index >= clothes.Length)
            return;

        for (int i = 0; i < clothes.Length; i++)
        {
            clothes[i].SetActive(i == index);
        }
    }
}

```

Guardá el archivo y volvé a Unity. Esperá a que termine de compilar.

## **Paso 7. Conectar el script con Unity**

1. Seleccioná `ClothingManager` en Hierarchy.
2. En Inspector, presioná `Add Component`.
3. Buscá `ClothingManager`.
4. Agregalo.

Ahora vas a encontrar tres listas:

- Tops
- Bottoms
- Shoes

Tenemos que asignar las prendas.

[unity - Get all images from folder and set them in a list? - Game Development Stack Exchange](https://images.openai.com/static-rsc-4/mi7AgNGC8FghofoVxqMDsh98AFppNn0RWNMexP2nrPSusLvJHbn7TzuDzul8WyA7W2-4jVKxxhDi5UmK4Ut_nhngJkQCKnfKr9ezzenVYcWJcJi_WOaY6IOdHnqYL5ppf37O4lwLrLD5hho1Dp07XlYvbnItbTJeCAuSgwhFp4Q?purpose=inline)

[gamedev.stackexchange.com](https://gamedev.stackexchange.com/questions/201164/get-all-images-from-folder-and-set-them-in-a-list?utm_source=chatgpt.com)

### **Cómo completar las listas**

En `Tops`:

1. Cambiá `Size` a 3.
2. Arrastrá `Top1` al Element 0.
3. Arrastrá `Top2` al Element 1.
4. Arrastrá `Top3` al Element 2.

En `Bottoms`:

- Size: 3.
- Element 0: Bottom1.
- Element 1: Bottom2.
- Element 2: Bottom3.

En `Shoes`:

- Size: 2.
- Element 0: Shoes1.
- Element 1: Shoes2.

**Importante:** aunque algunos objetos estén desactivados, podés arrastrarlos desde Hierarchy a las listas.

## **Paso 8. Hacer una primera prueba**

Todavía no necesitamos botones.

Vamos a comprobar que el script funciona desde el Inspector.

Para eso, después podemos utilizar botones de prueba o un pequeño método temporal, pero primero terminemos las conexiones.

# **ETAPA 3. Crear los botones para seleccionar las prendas**

Ahora vamos a conectar las opciones de ropa con el script.

Como ya tienen `ClothingPanel` dentro del Canvas, vamos a utilizarlo.

## **Paso 9. Crear los botones**

En Hierarchy:

1. Desplegá `GameCanvas`.
2. Seleccioná `ClothingPanel`.
3. Clic derecho sobre él.
4. Elegí `UI > Button - TextMeshPro`.
5. Si Unity pide importar TMP Essentials, aceptá.

Cambiale el nombre a `ButtonTop1`.

Repetí para crear:

- ButtonTop1
- ButtonTop2
- ButtonTop3
- ButtonBottom1
- ButtonBottom2
- ButtonBottom3
- ButtonShoes1
- ButtonShoes2

Cada botón representará una prenda.

[​​Bring Ready Player Me avatars to your Discord Activities - Ready Player Me Blog](https://images.openai.com/static-rsc-4/Xoq5zpStzaiOeO_cr0xCRM0MwuKMBwty1o9DBzF-SlXWKgEmuTmPUiJgX81EWrMwAkhYY4ojB3iJquyG1O1Yru6vME-QJcs2BkyBJw5d_r2xNpch-zUSlOTkTLszxJwGBfI0hzGSLS-9BV-DQIjrtcpGe-7lTF9YmnKGHstV9HI?purpose=inline)

[readyplayer.me](https://readyplayer.me/blog/bring-ready-player-me-avatars-to-your-discord-activities?utm_source=chatgpt.com)

## **Paso 10. Colocar las imágenes en los botones**

Seleccioná `ButtonTop1`.

En su componente `Image`, asigná el dibujo del primer top.

Repetí con los demás botones y sus respectivas imágenes.

Si no quieren que aparezca texto, pueden borrar el objeto hijo `Text (TMP)` de cada botón.

## **Paso 11. Conectar los botones con ClothingManager**

Este paso es fundamental.

Seleccioná `ButtonTop1`.

En el Inspector buscá el componente `Button`.

En la sección `On Click()`:

1. Presioná el botón `+`.
2. Arrastrá el GameObject `ClothingManager` desde Hierarchy al campo vacío.
3. Abrí el desplegable `No Function`.
4. Seleccioná `ClothingManager > SelectTop (int)`.
5. En el campo numérico colocá `0`.

Repetí:

| Botón         | Función      | Número |
| ------------- | ------------ | ------ |
| ButtonTop1    | SelectTop    | 0      |
| ButtonTop2    | SelectTop    | 1      |
| ButtonTop3    | SelectTop    | 2      |
| ButtonBottom1 | SelectBottom | 0      |
| ButtonBottom2 | SelectBottom | 1      |
| ButtonBottom3 | SelectBottom | 2      |
| ButtonShoes1  | SelectShoes  | 0      |
| ButtonShoes2  | SelectShoes  | 1      |

[Changing Skyboxes - Unity Learn](https://images.openai.com/static-rsc-4/VXCnHFQFDjSka1S_REB9zyg5iLm3-pjhqF2dPviEIr_FjcSM7B-ZF76GoAL7ZdSEqve5lhJNCz86_nbyoah_o_MTeWe94qWeNhYXSiCJRoTE4NAIf_m0O6thelikb6CYh0-37vTMeivfMUKwTMK9eh4-NtN-itKLnk4IG0Vk6n8?purpose=inline)

[learn.unity.com](https://learn.unity.com/course/architecture-engineering-and-construction-curricular-framework-resources/tutorial/changing-skyboxes?utm_source=chatgpt.com)

¡Ahora sí! Cuando presionen un botón, la modelo debería cambiar la prenda correspondiente sin modificar las demás.

# **ETAPA 4. Comprobar que funcione**

Presioná Play y probá:

- Seleccionar otro top.
- Cambiar la pollera.
- Cambiar los zapatos.
- Volver a seleccionar las prendas anteriores.

Primer sistema funcional

Si todo funciona, ya tienen una parte importante del videojuego programada: la selección y sustitución de prendas.

# **¿Qué viene después?**

Una vez que esto funcione, vamos a construir el verdadero desafío de memoria:

**FASE 1 — Memorizar**

[Fille Adorable Et Jolie - Comment jouer et jeu gratuit sur navigateur | CrazyGames-Poki](https://images.openai.com/static-rsc-4/vidmMssCXWdPXEB4_seC2dV6Z009qNdIx0G0yCBJTcX84cufCbII0aVDVo7Nn561qR05OHiD2NdKGSYX81N_mxW1VxOFRRj0T7_I9CruBf-ScqHryDMg5vIMq_83qBY-FG0oN7IxFhjjHooMm21qzsSbAazVPBiUgZYyLp-pMWM?purpose=inline)

[crazygames-poki.com](https://crazygames-poki.com/fr/girls/lovely-cute-girl?utm_source=chatgpt.com)

La modelo aparece con un conjunto determinado durante unos segundos.

**FASE 2 — Ocultar**\
La ropa desaparece y comienza el desafío.

**FASE 3 — Reconstruir**

[Desafio da Moda de Nova York - Jogo Gratuito Online | FunnyGames](https://images.openai.com/static-rsc-4/VLnyaAc0huJsBd7te80GN0d54fFydrVeeTPUVHikr3842T5eo6vkPUoaY3DQ8yoLaYUCqx_8ocaEmTRzFPcdQ4ierNV2pSfqJvEaO7RmgWtehq8KTHS9BQKxm8BeCv9gmlSGUEmr09Nathn9wkBUC-S1afllgVWNhO_oOb8Ehoc?purpose=inline)

[funnygames.com.br](https://www.funnygames.com.br/jogo/desafio_da_moda_de_nova_york.html?utm_source=chatgpt.com)

Aparecen las opciones correctas e incorrectas.

**FASE 4 — Comprobar**\
Se verifican las elecciones, se descuentan vidas y se calcula el puntaje.

## **Antes de avanzar, quiero que hagan una prueba**

No pasen todavía al temporizador ni a las vidas.

Primero necesito saber si consiguieron que los botones cambien la ropa correctamente.

**¿La modelo ya puede cambiar de top, bottom y shoes al presionar los botones, o les aparece algún error en Console?**

Si me mandás una captura de la Hierarchy y del Inspector de `ClothingManager`, puedo revisar que esté todo bien conectado. 💗