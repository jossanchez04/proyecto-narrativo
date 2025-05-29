using System.Collections.Generic;
using UnityEngine;

public class NPC_Stories : MonoBehaviour
{
    public static List<NPCStory> npcStories = new List<NPCStory>()
    {
        new NPCStory(
            "Linares",
            "Me llamo Linares. Antes del colapso, fui agricultor en tierras �ridas donde el sol castigaba sin misericordia y el agua se med�a gota a gota. Aprend� a sacar alimento de la tierra seca y a cuidar cada semilla como si fuera un tesoro. Tras el desastre, mi campo qued� seco y sin futuro, y tuve que dejarlo todo atr�s. Ahora llego a este refugio rogando por un pedazo de tierra donde plantar. S� que puedo alimentar a muchos si me dan esa oportunidad, aunque debo ser honesto: mis cultivos necesitan mucha agua, y s� que ese recurso es escaso. Dar� lo mejor de m� para hacer que nuestro refugio prospere.",
            food: 4, water: -2, morale: 3, materials: 1, strenght: 1
        ),

        new NPCStory(
            "Hugo",
            "Mi nombre es Hugo. Fui mec�nico en la ciudad y cuando la civilizaci�n se vino abajo, mi taller se convirti� en mi refugio. Recog�a piezas rotas, hierros y cables desechados para darles nueva vida y mantener funcionando lo que pudiera. Aqu� puedo ayudar con materiales y reparaciones, pero soy un hombre solitario, poco dado a las palabras amables y a levantar �nimos. A veces, mi presencia puede pesar y bajar la moral de los dem�s. Sin embargo, si me respetan y entienden mi car�cter, prometo ser un pilar fuerte para este refugio.",
            food: -1, water: 0, morale: -3, materials: 5, strenght: 3
        ),

        new NPCStory(
            "Mayael",
            "Me llamo Mayael. Fui enfermero y aprend� a cuidar heridas, enfermedades y dolores que parec�an imposibles de sanar. En estos tiempos dif�ciles, traigo conmigo un peque�o botiqu�n con lo poco que queda de medicina. Mi presencia calma a quienes sufren, y eso ayuda a mantener la esperanza viva. Pero no todo es perfecto: desde que empez� esta pesadilla, he sufrido dolores de cabeza constantes que me dejan d�bil para trabajos pesados. Aun as�, estoy dispuesto a ayudar en todo lo que pueda para salvar vidas.",
            food: -1, water: 1, morale: 5, materials: 0, strenght: 0
        ),

        new NPCStory(
            "Jared",
            "Soy Jared, exsoldado y experto en supervivencia. He recorrido terrenos peligrosos y s� c�mo defender y proveer para un grupo. Puedo liderar expediciones para conseguir recursos y proteger este refugio de cualquier amenaza. Sin embargo, las noches son largas y mis pesadillas implacables. A menudo, mi car�cter duro y mal humor genera tensiones en el grupo. Necesito respeto y espacio para controlar mis demonios, pero si me lo dan, ser� un aliado invaluable.",
            food: 0, water: -1, morale: -3, materials: 4, strenght: 5
        ),

        new NPCStory(
            "Noel",
            "Soy Noel, chef de profesi�n. S� transformar los pocos ingredientes en comidas que alimentan el cuerpo y levantan el �nimo. Cocinar es mi manera de mantener la esperanza y la uni�n. Sin embargo, padezco alergias que me obligan a consumir alimentos especiales y no siempre puedo compartir plenamente. Esto hace que a veces gaste m�s recursos de los que produzco, pero la alegr�a y moral que aporto justifican ese costo. Si me aceptas, prometo que nadie aqu� tendr� hambre sin sabor.",
            food: 3, water: 1, morale: 4, materials: -2, strenght: 0
        ),

        new NPCStory(
            "Samir",
            "Me llamo Samir y soy ingeniero hidr�ulico. Cuando todo se vino abajo, us� mis conocimientos para construir sistemas improvisados que recolectan y purifican agua, incluso cuando la fuente parece imposible. Puedo traer abundante agua al refugio y mejorar su uso. Confieso que a veces me obsesiono con mis proyectos y dejo de lado a las personas, lo que puede bajar la moral de quienes me rodean. Pero si me das espacio para trabajar, ser� fundamental para mantenernos hidratados y fuertes.",
            food: 0, water: 5, morale: -1, materials: 3, strenght: 2
        ),

        new NPCStory(
            "Evaristo",
            "Soy Evaristo, antes bibliotecario y organizador comunitario. Mi trabajo era mantener vivas las historias y las esperanzas de mi gente, y eso es lo que ofrezco aqu�: relatos, liderazgo y uni�n. No traigo fuerza ni materiales, pero la moral que genero puede marcar la diferencia entre seguir luchando o caer en la desesperanza. Mi cuerpo es fr�gil y no puedo acompa�ar expediciones largas, pero siempre estar� aqu� para sostener el esp�ritu del refugio.",
            food: 0, water: 0, morale: 5, materials: 0, strenght: 0
        ),

        new NPCStory(
            "Ricardo",
            "Me llamo Ricardo y soy minero. He pasado a�os en minas contaminadas que dejaron mi cuerpo maltrecho, pero a�n conservo la fuerza necesaria para el trabajo duro y la extracci�n de materiales. Necesito mucha comida y agua para mantenerme activo, pero si me das lo que necesito, puedo ser un motor para las expediciones y las labores pesadas. No soy muy expresivo ni sociable, pero cuando la supervivencia est� en juego, los hechos hablan por m�.",
            food: -2, water: -1, morale: 0, materials: 4, strenght: 5
        ),

        new NPCStory(
            "Lorenzo",
            "Soy Lorenzo, cantante y animador. Mi voz ha sido un refugio para muchos en las noches m�s oscuras. Puedo levantar la moral y traer alegr�a cuando parece que ya no queda nada. Sin embargo, una vieja herida me impide hacer trabajos f�sicos y aportar en comida o materiales. Aun as�, muchos dicen que mi canto mantiene vivos los corazones y eso no es poco en estos tiempos.",
            food: -1, water: -1, morale: 5, materials: 0, strenght: 0
        ),

        new NPCStory(
            "Tom�s",
            "Me llamo Tom�s y vengo del bosque, donde cazaba y recolectaba para sobrevivir. Cuando todo se vino abajo, mis habilidades me salvaron la vida y ahora traigo conmigo recursos y fuerza para las expediciones. Soy reservado y no siempre me adapto bien a la convivencia en grupo, mi silencio y distancia a veces causan conflictos. Pero si me necesitas para una misi�n, soy de los mejores para traer lo que hace falta.",
            food: 2, water: 1, morale: -2, materials: 3, strenght: 4
        ),
        new NPCStory(
            "Sim�n",
            "Por favor, necesito un lugar donde quedarme. No tengo mucho para ofrecer, s�lo unas pocas latas de comida y algo de agua. La soledad me ha hecho perder fuerzas, pero estoy dispuesto a ayudar en lo que pueda. S� que no soy un gran aporte, pero por favor, d�jeme entrar. No quiero morir afuera solo.",
            food: -1, water: -1, morale: 1, materials: 0, strenght: 0
        ),
        new NPCStory(
            "Ram�n",
            "Me llamo Ram�n. Vengo huyendo de la nada, sin nada que dar. Solo busco un techo y algo de comida. Estoy cansado, y mi cuerpo ya no da para mucho. Si me dejan entrar, prometo no ser una carga, aunque s� que apenas podr� aportar algo �til.",
            food: -1, water: 1, morale: 0, materials: 1, strenght: 0
        ),
        new NPCStory(
            "Dimitri",
            "Me llaman Dimitri, y no estoy aqu� para hacer amigos. Soy un ladr�n y un oportunista. Puedo conseguir comida y materiales, pero a trav�s de m�todos poco morales. Mi presencia solo genera desconfianza y peleas. Si me aceptan, ser� bajo mis t�rminos, no los suyos.",
            food: 1, water: 1, morale: -4, materials: 4, strenght: 3
        ),
        new NPCStory(
            "Viktor",
            "Me llamo Viktor. He aprendido a ser autosuficiente en estos tiempos dif�ciles, y siempre consigo lo que necesito para sobrevivir. Puedo aportar materiales valiosos y fuerza para las expediciones. Soy directo y no suelo andar con rodeos, prefiero la acci�n a las palabras, y eso a veces puede causar diferencias con otros. Pero cuando se trata de proteger el refugio, soy alguien en quien se puede confiar.",
            food: -4, water: -5, morale: -6, materials: 1, strenght: 5
        ),
        new NPCStory(
            "Esteban",
            "Soy Esteban. Vengo con la intenci�n de aportar y encontrar un lugar seguro. Traigo algunos recursos conmigo y me esfuerzo por integrarme al grupo. A veces puedo parecer reservado o un poco distante, pero es solo porque he pasado por mucho y a�n trato de encontrar mi lugar aqu�. Estoy dispuesto a ayudar en lo que sea necesario, aunque reconozco que a veces mis acciones no siempre agradan a todos.",
            food: 1, water: 1, morale: -2, materials: 1, strenght: 1
        ),
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
