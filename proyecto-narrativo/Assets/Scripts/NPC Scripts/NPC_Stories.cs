using System.Collections.Generic;
using UnityEngine;

public class NPC_Stories : MonoBehaviour
{
    public static List<NPCStory> npcStories = new List<NPCStory>()
    {
        new NPCStory("Mohammed", "Hola, me llamo Mohammed. Soy de lo que antes era conocido como Turquía. He sufrido bastante durante las diversas dictaduras que me tocó vivir junto a mi familia. Durante todo ese tiempo, aprendí a moverme a través del caos que ocasionaron los enfrentamientos en mi país. Diría que soy bastante hábil para obtener suministros, muchas veces me intentaron robar pero nunca lo permití. Tuve que hacer lo que fuese necesario para proteger y alimentar a mi familia.",
        food: 1, water: 1, morale: 2, materials: 4, strenght: 3),

        new NPCStory("Mateo", "Hola, me llamo Mateo. Vivía en Italia y ejercí como paramédico con mis mejores amigos. En tiempos de guerra, me tocó curarlos cuando ellos sufieron heridas graves, pero no los pude salvar. Preparaba sueros caseros para que ellos se hidrataran, como no se puede consumir el agua todavía. Suelo tocar la guitarra para relajarme y personas me han comentado que esto les ha ayudado también.",
        food: -1, water: 3, morale: 5, materials: 0, strenght: -2),

        new NPCStory("Charles", "Soy Charles, un ingeniero civil belga y trabajé en una planta de tratamiento de aguas. He sido capaz de construir filtros caseros que hacen rendir el agua potable. Nunca he sido capaz de aguantar a personas que no hacen su mejor esfuerzo cuando trabajan conmigo. Yo no soy un gasto de comida, solo necesito cigarros y eso me mantiene activo.",
        food: 0, water: 4, morale: 1, materials: 5, strenght: -3),

        new NPCStory("Diego", "Buenas, soy Diego. Yo era un antiguo profesor de literatura en la Universidad de Valencia. Cada noche podría organizar espacios de poesía para que todos podamos expresar nuestros pensamientos. Soy muy organizado y prometo tener buen cuidado a la hora de llevar la cuenta de los alimentos.",
        food: -2, water: 0, morale: 5, materials: 1, strenght: -4),

        new NPCStory("Isaac", "Hola, me llamo Isaac. Soy de Algeria, aunque ya no sé si todavía existe. Fui chef de un restaurante exitoso, donde aprendí a plantar mis propios vegetales para cocinarlos. Esa fue una de las principales lecciones que me enseñó mi abuelo, quien también me enseñó a seguir adelante sin importar la situación. Siempre he tenido un ayudante, dado que tengo ciertos impedimentos debido a mi anemia.",
        food: 4, water: 2, morale: 3, materials: 2, strenght: -1),

        new NPCStory("Nikos", "Hola, me llamo Nikos. Soy de Grecia, tierra destrozada por la política. Crecí en una familia con muy poco dinero, entonces recolectaba materiales que la gente desechaba. En mi casa, me encargaba de arreglar cualquier pared, lámina de techo o pared que estuviera rota. Vivían 15 personas en mi casa, donde aprendí a pelearme por raciones de comida. Dada mi estatura, nadie quiere pelear conmigo.",
        food: 2, water: 0, morale: 1, materials: 5, strenght: 4),

        new NPCStory("Joel", "Hola, me llamo Joel. Nací en Sudáfrica en época del Apartheid. Mi familia era dueña de minas de carbón. Cuándo mi papá falleció, me hice cargo de la mina. Por esto considero que soy un gran líder, ya que me ayudó a conocer gente de poder. Siempre he sabido dar órdenes, y no tener un apego emocional si personas hacen bien su trabajo. Además, siempre he hecho stand up por amor al arte, y espero que me paguen con ron.",
        food: 1, water: 1, morale: 3, materials: 3, strenght: 5),

        new NPCStory("Omar", "Hola, me llamo Omar. Soy de Irlanda, el único terreno del Reino Unido que sobrevivió la guerra. Ser hijo de padres inmigrantes me ayudó a tener empatía con las personas, ya que muchos no somos aceptados por nuestros orígenes. Durante unos años, talé árboles para hacer leña para calentar el hogar que tenía con mi familia. Te prometo que no como mucho, solo es que tengo las costillas salidas.",
        food: 0, water: 2, morale: 4, materials: 1, strenght: -2),

        new NPCStory("Tiago", "Soy Tiago, un arquitecto brasileño y conseguí varios trabajos sin haber estudiado. Reconstruía casas con mi creatividad y recolectando materiales por mi cuenta. Soy una persona callada por lo general, pero hago el intento de sonreír.",
        food: -1, water: -1, morale: 3, materials: 5, strenght: -1),

        new NPCStory("Mark", "Hola, me llamo Mark. Yo soy un políglota y sé hablar inglés, mandarín y ruso. Mis padres me mandaron a estudiar a estos idiomas para que estuviera preparado para la guerra. Soy alérgico al gluten, así que tengo que comer comidas especiales.",
        food: -1, water: -1, morale: 3, materials: 1, strenght: -3),

        new NPCStory("Anton", "Me llamo Anton. Vengo de Serbia. He cazado y cocinado cualquier tipo de animal. Soy hábil con un rifle. Me pueden servir barro de comer y me lo como.",
        food: 4, water: 0, morale: -2, materials: 2, strenght: 5),

        new NPCStory("Arnold", "Me llamo Arnold. Soy de Polonia y he sido durante muchos años. Considero importante que toda las personas sean abiertas a la religión. Ojalá nadie me escuche pero puedo convertir el agua sucia en agua potable.",
        food: -1, water: 5, morale: 3, materials: 2, strenght: -3),

        new NPCStory("Brahim", "Hola, me llamo Brahim y soy marroquí. Tengo una esposa y 3 hijos, a los que espero ver pronto, los extraño mucho. Mi familia tenía una panadería antes de que cayera la bomba en Europa. Tengo que ser sincero, presento una condición de sudoración excesiva.",
        food: 1, water: -2, morale: -3, materials: 1, strenght: 0),
    };
}

public class NPCStory
    {
    public string npcName;
    public string npcBackstory;
    // Attributes for NPC
    public int food;
    public int water;
    public int morale;
    public int materials;
    public int strenght;

    public NPCStory(string name, string backstory, int food = 0, int water = 0, int morale = 0, int materials = 0, int strenght = 0)
    {
        npcName = name;
        npcBackstory = backstory;
        this.food = food;
        this.water = water;
        this.morale = morale;
        this.materials = materials;
        this.strenght = strenght;
    }
}
