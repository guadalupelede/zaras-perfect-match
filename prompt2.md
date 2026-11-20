¡Hola, Guadalupe\! Qué gran proyecto tenés entre manos con **Zara's Perfect Match**. Vamos a trabajar de forma ordenada, limpia y sin tocar lo que ya acomodaste visualmente hasta entender exactamente qué está pasando en cada capa.

### **1\. Diagnóstico puntual: qué causa el cuadrado grande y los botones desordenados**

Cuando en **Scene View** se ve prolijo y al pasar a **Game View** o darle **Play** aparece un bloque gris/blanco gigante o los botones se amontonan, casi siempre se debe a uno o más de estos cuatro factores en la UI:

> 1. **Un panel o imagen cubriendo el Canvas (orden de jerarquía o Raycast Target / Color):**  
   * En Unity, los elementos de UI se dibujan **de arriba hacia abajo** en la Hierarchy: lo que está más abajo se dibuja *encima* de lo que está arriba.  
   * Si algún panel (InstructionsPanel, GameOverPanel, ScorePanel o un fondo dentro de ClothingPanel / PanelGridVisual) quedó **activo** o al final de la lista con un color blanco/gris semi-opaco o sin sprite asignado (el *Default UI Sprite* es un cuadrado blanco), tapa todo o parte de la pantalla.  
   * *Dato clave:* aunque desactives el componente Image o le bajes el Alpha a 0 si solo querés que sea un contenedor invisible, es más limpio usar un GameObject vacío con RectTransform o dejar Image con Alpha 0 solo si necesitás que reciba clics.  
> 2. **Layout Groups peleando con tus posiciones manuales:**  
   * Si PanelGridVisual, TopsGrids, BottomsGrids o ShoesGrids tienen un **Horizontal Layout Group**, **Vertical Layout Group** o **Grid Layout Group**, esos componentes **ignoran** las posiciones que acomodaste a mano y recolocan los hijos automáticamente (a veces apilándolos en una esquina o encogiéndolos a tamaño 0 si falta Content Size Fitter / tamaño de celda).  
   * Si acomodaste TopButton1, TopButton2, etc. a mano, **no debería haber un Layout Group encima** pisando sus coordenadas.  
> 3. **Anchors (anclas) y Pivot desalineados entre resoluciones:**  
   * En Scene View podés tener una relación de aspecto distinta a la de Game View (por ejemplo, *Free Aspect* vs *16:9* o *1920x1080*). Si un botón tiene anclas estiradas o apuntando a una esquina distinta a donde lo dejaste, al cambiar la ventana o iniciar el juego se desplaza.  
> 4. **Canvas Scaler sin escalado uniforme:**  
   * Si el Canvas tiene UI Scale Mode en **Constant Pixel Size**, en pantallas con distinta resolución los elementos cambian de tamaño relativo y pueden encimarse o salirse de su contenedor. Lo habitual en juegos 2D es usar **Scale With Screen Size** con una resolución de referencia (por ejemplo, 1920x1080 o 1280x720).

#### **Qué revisar en el Inspector antes de tocar código**

* **En Canvas:** revisá que Render Mode sea Screen Space \- Overlay (lo más simple y directo para UI 2D), y en Canvas Scaler probá Scale With Screen Size con Match alrededor de 0.5.  
* **En los paneles (InstructionsPanel, GameOverPanel, ScorePanel):** verificá cuáles deben arrancar **desactivados** (casilla arriba a la izquierda del Inspector) para que no tapen el minijuego al empezar.  
* **En PanelGridVisual, TopsGrids, BottomsGrids, ShoesGrids:** fijate si tienen algún componente \*Layout Group. Si querés mantener tu acomodo manual, quitá esos Layout Groups (o desactivalos) y revisá que los botones no tengan tamaños extremos.  
* **En EventSystem:** asegurarte de que exista un solo EventSystem en la escena (si hay dos, los clics pueden comportarse raro).

### **2\. Paso (a): Dejar estable la UI y los botones antes de programar**

Hagamos esto en orden para no perder tu diseño actual:

> 1. **Fijá una resolución de prueba en Game View:** elegí una resolución fija (por ejemplo 1920x1080 o 1280x720) en vez de *Free Aspect*, así ves exactamente cómo escala todo.  
> 2. **Ocultá paneles que no corresponden al inicio:** desactivá InstructionsPanel y GameOverPanel si están tapando la pantalla. Si ves un cuadrado gris/blanco grande, seleccioná el objeto en Scene View (o usá la herramienta de selección) para ver qué GameObject exacto es y revisá su Image (color/alpha) y su posición en la Hierarchy.  
> 3. **Protegé la posición manual de los botones:**  
   * Revisá TopsGrids, BottomsGrids y ShoesGrids. Si tienen un Grid Layout Group / Horizontal Layout Group / Vertical Layout Group que te está desordenando los botones, **quitá ese componente** (clic en los tres puntos del componente \-\> *Remove Component*).  
   * Seleccioná cada botón (TopButton1, etc.) y verificá su RectTransform (Pos X, Pos Y, Width, Height) y sus Anchors. Si querés que conserven su posición relativa al grupo, presioná Alt \+ clic sobre el recuadro de Anchors solo cuando estés segura de qué esquina o centro querés anclar (normalmente centro o esquina del contenedor).  
> 4. **Verificá que CharacterModel no quede tapado por un fondo opaco:**  
   * Como CharacterModel (Body, Tops, Bottoms, Shoes) está fuera del Canvas como objeto 2D del mundo/escena, asegurate de que su Sorting Layer / Order in Layer esté por delante del fondo (videojuego) y de ropero nuevo@3x\_0 si corresponde, y que el Canvas no tenga un fondo sólido cubriendo toda la pantalla por encima de la modelo.

### **3\. Paso (b): Hacer funcionar la selección de prendas sobre la modelo**

Acá conectamos la UI (TopButton1, etc., dentro del Canvas) con los hijos de CharacterModel (Tops, Bottoms, Shoes, que usan SpriteRenderer).

#### **Por qué es limpio hacerlo así (evitando errores de coordenadas)**

Los botones de la UI viven en **espacio de UI (RectTransform / Canvas)**, mientras que CharacterModel (Tops, Bottoms, Shoes) vive en **espacio de escena 2D (Transform \+ SpriteRenderer)**.  
Si en vez de mover coordenadas a mano entre UI y mundo **ya dejás acomodados los objetos hijos Tops, Bottoms y Shoes dentro de CharacterModel** con su posición, escala y Order in Layer correctos en la escena, al hacer clic en un botón **solo hay que cambiar spriteRenderer.sprite y activar el objeto**. Así no hay peleas de píxeles vs. unidades del mundo.

#### **Script 1: OutfitPieceData.cs (o directamente en el botón / controlador)**

Para mantenerlo simple y sin complicarte con ScriptableObject todavía, podemos crear un componente chiquito **ClothingButton.cs** que va en cada botón de prenda (TopButton1, TopButton2, etc.).

C\#  
using UnityEngine;  
using UnityEngine.UI;

public enum ClothingCategory  
{  
    Top,  
    Bottom,  
    Shoes  
}

\[RequireComponent(typeof(Button))\]  
public class ClothingButton : MonoBehaviour  
{  
    \[Header("Configuración de la prenda")\]  
    public ClothingCategory category;  
    public Sprite pieceSprite;

    \[Header("Referencia al controlador")\]  
    public WardrobeController wardrobeController;

    private Button button;

    private void Awake()  
    {  
        button \= GetComponent\<Button\>();  
    }

    private void OnEnable()  
    {  
        if (button \!= null)  
        {  
            button.onClick.AddListener(OnClothingSelected);  
        }  
    }

    private void OnDisable()  
    {  
        if (button \!= null)  
        {  
            button.onClick.RemoveListener(OnClothingSelected);  
        }  
    }

    private void OnClothingSelected()  
    {  
        if (wardrobeController \== null)  
        {  
            Debug.LogWarning(\$"\[ClothingButton\] Falta asignar WardrobeController en {gameObject.name}", this);  
            return;  
        }

        if (pieceSprite \== null)  
        {  
            Debug.LogWarning(\$"\[ClothingButton\] Falta asignar pieceSprite en {gameObject.name}", this);  
            return;  
        }

        wardrobeController.EquipPiece(category, pieceSprite);  
    }  
}

#### **Script 2: WardrobeController.cs**

Este script va en un objeto organizador de la escena (por ejemplo, un objeto vacío llamado MiniGameController o en CharacterModel). Se encarga de recibir la categoría y el Sprite, y ponerlo en el SpriteRenderer correspondiente.

C\#  
using UnityEngine;

public class WardrobeController : MonoBehaviour  
{  
    \[Header("SpriteRenderers en CharacterModel")\]  
    public SpriteRenderer topRenderer;  
    public SpriteRenderer bottomRenderer;  
    public SpriteRenderer shoesRenderer;

    \[Header("Opcional: si querés desactivar cuando no hay prenda")\]  
    public bool hideWhenSpriteIsNull \= true;

    public void EquipPiece(ClothingCategory category, Sprite newSprite)  
    {  
        SpriteRenderer targetRenderer \= GetRendererByCategory(category);

        if (targetRenderer \== null)  
        {  
            Debug.LogWarning(\$"\[WardrobeController\] No hay SpriteRenderer asignado para la categoría {category}.", this);  
            return;  
        }

        targetRenderer.sprite \= newSprite;

        if (hideWhenSpriteIsNull)  
        {  
            targetRenderer.enabled \= (newSprite \!= null);  
        }  
    }

    public void ClearPiece(ClothingCategory category)  
    {  
        EquipPiece(category, null);  
    }

    public void ClearAll()  
    {  
        ClearPiece(ClothingCategory.Top);  
        ClearPiece(ClothingCategory.Bottom);  
        ClearPiece(ClothingCategory.Shoes);  
    }

    private SpriteRenderer GetRendererByCategory(ClothingCategory category)  
    {  
        switch (category)  
        {  
            case ClothingCategory.Top:  
                return topRenderer;  
            case ClothingCategory.Bottom:  
                return bottomRenderer;  
            case ClothingCategory.Shoes:  
                return shoesRenderer;  
            default:  
                return null;  
        }  
    }  
}

#### **Dónde va cada cosa y qué arrastrar en el Inspector**

> 1. **En CharacterModel:**  
   * Asegurate de que los hijos Tops, Bottoms y Shoes tengan un componente **Sprite Renderer**.  
   * Acomodá a mano en la escena la posición local (Position), rotación y escala de Tops (torso), Bottoms (caderas/piernas) y Shoes (pies) respecto a Body, y ajustá su **Order in Layer** para que las prendas queden por encima de Body y en el orden que te guste (por ejemplo: Body \= 1, Bottoms \= 2, Tops \= 3, Shoes \= 2 o 3 según cómo calce).  
> 2. **Objeto WardrobeController:**  
   * Creá un GameObject vacío en la escena llamado WardrobeController y agregale el script WardrobeController.cs.  
   * Arrastrá desde CharacterModel:  
     * Tops \-\> campo **Top Renderer**  
     * Bottoms \-\> campo **Bottom Renderer**  
     * Shoes \-\> campo **Shoes Renderer**  
> 3. **En cada botón (TopButton1, TopButton2, TopButton3, y los de Bottoms/Shoes):**  
   * Agregale el componente ClothingButton.cs.  
   * Elegí **Category** (Top, Bottom o Shoes).  
   * Arrastrá el **Sprite** de esa prenda (desde Assets \> Sprites \> Clothes \> ...) al campo **Piece Sprite**.  
   * Arrastrá el objeto WardrobeController al campo **Wardrobe Controller**.

#### **Cómo evitar errores de null o de coordenadas**

* **NullReferenceException:** ambos scripts validan con if (... \== null) y lanzan un Debug.LogWarning indicando exactamente qué objeto tiene el campo vacío, sin romper el juego.  
* **Desfasaje de coordenadas UI vs. Mundo:** al no calcular posiciones de pantalla a mundo por código en este primer paso, **la posición de cada prenda en la modelo depende de cómo dejaste Tops, Bottoms y Shoes bajo CharacterModel**. Si una remera queda corrida, movés el objeto Tops en la escena hasta que encaje perfecto con Body y listo.

### **Cómo seguimos ahora**

Probá primero **el Paso (a)** para limpiar ese cuadrado gris/blanco y estabilizar los botones en Game View, y luego **el Paso (b)** con un par de botones de prueba. Cuando me cuentes cómo se ve y qué pasa al hacer clic, pasamos al **Paso (c)** (memorización de 10 segundos, validación del outfit, 3 estrellas/vidas, outfits aleatorios y GameOverPanel).