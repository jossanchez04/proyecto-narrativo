using System.Collections.Generic;
using UnityEngine;

public class NPC_Stories : MonoBehaviour
{
    public static List<NPCStory> npcStories = new List<NPCStory>()
    {
        new NPCStory("Mohammed", "Hola, me llamo Mohammed. Soy de lo que antes era conocido como Turqu�a. He sufrido bastante durante las diversas dictaduras que me toc� vivir junto a mi familia. Durante todo ese tiempo, aprend� a moverme a trav�s del caos que ocasionaron los enfrentamientos en mi pa�s. Dir�a que soy bastante h�bil para obtener suministros, muchas veces me intentaron robar pero nunca lo permit�. Tuve que hacer lo que fuese necesario para proteger y alimentar a mi familia."),

        new NPCStory("Mateo", "Hola, me llamo Mateo. Viv�a en Italia y ejerc� como param�dico con mis mejores amigos. En tiempos de guerra, me toc� curarlos cuando ellos sufieron heridas graves, pero no los pude salvar. Preparaba sueros caseros para que ellos se hidrataran, como no se puede consumir el agua todav�a. Suelo tocar la guitarra para relajarme y personas me han comentado que esto les ha ayudado tambi�n."),

        new NPCStory("Charles", "Soy Charles, un ingeniero civil belga y trabaj� en una planta de tratamiento de aguas. He sido capaz de construir filtros caseros que hacen rendir el agua potable. Nunca he sido capaz de aguantar a personas que no hacen su mejor esfuerzo cuando trabajan conmigo. Yo no soy un gasto de comida, solo necesito cigarros y eso me mantiene activo."),

        new NPCStory("Diego", "Buenas, soy Diego. Yo era un antiguo profesor de literatura en la Universidad de Valencia. Cada noche podr�a organizar espacios de poes�a para que todos podamos expresar nuestros pensamientos. Soy muy organizado y prometo tener buen cuidado a la hora de llevar la cuenta de los alimentos."),

        new NPCStory("Isaac", "Hola, me llamo Isaac. Soy de Algeria, aunque ya no s� si todav�a existe. Fui chef de un restaurante exitoso, donde aprend� a plantar mis propios vegetales para cocinarlos. Esa fue una de las principales lecciones que me ense�� mi abuelo, quien tambi�n me ense�� a seguir adelante sin importar la situaci�n. Siempre he tenido un ayudante, dado que tengo ciertos impedimentos debido a mi anemia."),

        new NPCStory("Nikos", "Hola, me llamo Nikos. Soy de Grecia, tierra destrozada por la pol�tica. Crec� en una familia con muy poco dinero, entonces recolectaba materiales que la gente desechaba. En mi casa, me encargaba de arreglar cualquier pared, l�mina de techo o pared que estuviera rota. Viv�an 15 personas en mi casa, donde aprend� a pelearme por raciones de comida. Dada mi estatura, nadie quiere pelear conmigo."),

        new NPCStory("Joel", "Hola, me llamo Joel. Nac� en Sud�frica en �poca del Apartheid. Mi familia era due�a de minas de carb�n. Cu�ndo mi pap� falleci�, me hice cargo de la mina. Por esto considero que soy un gran l�der, ya que me ayud� a conocer gente de poder. Siempre he sabido dar �rdenes, y no tener un apego emocional si personas hacen bien su trabajo. Adem�s, siempre he hecho stand up por amor al arte, y espero que me paguen con ron."),

        new NPCStory("Omar", "Hola, me llamo Omar. Soy de Irlanda, el �nico terreno del Reino Unido que sobrevivi� la guerra. Ser hijo de padres inmigrantes me ayud� a tener empat�a con las personas, ya que muchos no somos aceptados por nuestros or�genes. Durante unos a�os, tal� �rboles para hacer le�a para calentar el hogar que ten�a con mi familia. Te prometo que no como mucho, solo es que tengo las costillas salidas."),

        new NPCStory("Tiago", "Soy Tiago, un arquitecto brasile�o y consegu� varios trabajos sin haber estudiado. Reconstru�a casas con mi creatividad y recolectando materiales por mi cuenta. Soy una persona callada por lo general, pero hago el intento de sonre�r."),

        new NPCStory("Mark", "Hola, me llamo Mark. Yo soy un pol�glota y s� hablar ingl�s, mandar�n y ruso. Mis padres me mandaron a estudiar a estos idiomas para que estuviera preparado para la guerra. Soy al�rgico al gluten, as� que tengo que comer comidas especiales."),

        new NPCStory("Anton", "Me llamo Anton. Vengo de Serbia. He cazado y cocinado cualquier tipo de animal. Soy h�bil con un rifle. Me pueden servir barro de comer y me lo como."),

        new NPCStory("Arnold", "Me llamo Arnold. Soy de Polonia y he sido durante muchos a�os. Considero importante que toda las personas sean abiertas a la religi�n. Ojal� nadie me escuche pero puedo convertir el agua sucia en agua potable."),

        new NPCStory("Brahim", "Hola, me llamo Brahim y soy marroqu�. Tengo una esposa y 3 hijos, a los que espero ver pronto, los extra�o mucho. Mi familia ten�a una panader�a antes de que cayera la bomba en Europa. Tengo que ser sincero, presento una condici�n de sudoraci�n excesiva.")
    };
}

public class NPCStory
    {
    public string npcName;
    public string npcBackstory;

    public NPCStory(string name, string backstory)
    {
        npcName = name;
        npcBackstory = backstory;
    }
}
