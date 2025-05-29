using System.Collections.Generic;
using UnityEngine;

public class NPC_Stories : MonoBehaviour
{
    public static List<NPCStory> npcStories = new List<NPCStory>()
    {
        new NPCStory(
            "Linares",
            "Me llamo Linares. Antes del colapso, fui agricultor en tierras áridas donde el sol castigaba sin misericordia y el agua se medía gota a gota. Aprendí a sacar alimento de la tierra seca y a cuidar cada semilla como si fuera un tesoro. Tras el desastre, mi campo quedó seco y sin futuro, y tuve que dejarlo todo atrás. Ahora llego a este refugio rogando por un pedazo de tierra donde plantar. Sé que puedo alimentar a muchos si me dan esa oportunidad, aunque debo ser honesto: mis cultivos necesitan mucha agua, y sé que ese recurso es escaso. Daré lo mejor de mí para hacer que nuestro refugio prospere.",
            food: 4, water: -2, morale: 3, materials: 1, strenght: 1
        ),

        new NPCStory(
            "Hugo",
            "Mi nombre es Hugo. Fui mecánico en la ciudad y cuando la civilización se vino abajo, mi taller se convirtió en mi refugio. Recogía piezas rotas, hierros y cables desechados para darles nueva vida y mantener funcionando lo que pudiera. Aquí puedo ayudar con materiales y reparaciones, pero soy un hombre solitario, poco dado a las palabras amables y a levantar ánimos. A veces, mi presencia puede pesar y bajar la moral de los demás. Sin embargo, si me respetan y entienden mi carácter, prometo ser un pilar fuerte para este refugio.",
            food: -1, water: 0, morale: -3, materials: 5, strenght: 3
        ),

        new NPCStory(
            "Mayael",
            "Me llamo Mayael. Fui enfermero y aprendí a cuidar heridas, enfermedades y dolores que parecían imposibles de sanar. En estos tiempos difíciles, traigo conmigo un pequeño botiquín con lo poco que queda de medicina. Mi presencia calma a quienes sufren, y eso ayuda a mantener la esperanza viva. Pero no todo es perfecto: desde que empezó esta pesadilla, he sufrido dolores de cabeza constantes que me dejan débil para trabajos pesados. Aun así, estoy dispuesto a ayudar en todo lo que pueda para salvar vidas.",
            food: -1, water: 1, morale: 5, materials: 0, strenght: 0
        ),

        new NPCStory(
            "Jared",
            "Soy Jared, exsoldado y experto en supervivencia. He recorrido terrenos peligrosos y sé cómo defender y proveer para un grupo. Puedo liderar expediciones para conseguir recursos y proteger este refugio de cualquier amenaza. Sin embargo, las noches son largas y mis pesadillas implacables. A menudo, mi carácter duro y mal humor genera tensiones en el grupo. Necesito respeto y espacio para controlar mis demonios, pero si me lo dan, seré un aliado invaluable.",
            food: 0, water: -1, morale: -3, materials: 4, strenght: 5
        ),

        new NPCStory(
            "Noel",
            "Soy Noel, chef de profesión. Sé transformar los pocos ingredientes en comidas que alimentan el cuerpo y levantan el ánimo. Cocinar es mi manera de mantener la esperanza y la unión. Sin embargo, padezco alergias que me obligan a consumir alimentos especiales y no siempre puedo compartir plenamente. Esto hace que a veces gaste más recursos de los que produzco, pero la alegría y moral que aporto justifican ese costo. Si me aceptas, prometo que nadie aquí tendrá hambre sin sabor.",
            food: 3, water: 1, morale: 4, materials: -2, strenght: 0
        ),

        new NPCStory(
            "Samir",
            "Me llamo Samir y soy ingeniero hidráulico. Cuando todo se vino abajo, usé mis conocimientos para construir sistemas improvisados que recolectan y purifican agua, incluso cuando la fuente parece imposible. Puedo traer abundante agua al refugio y mejorar su uso. Confieso que a veces me obsesiono con mis proyectos y dejo de lado a las personas, lo que puede bajar la moral de quienes me rodean. Pero si me das espacio para trabajar, seré fundamental para mantenernos hidratados y fuertes.",
            food: 0, water: 5, morale: -1, materials: 3, strenght: 2
        ),

        new NPCStory(
            "Evaristo",
            "Soy Evaristo, antes bibliotecario y organizador comunitario. Mi trabajo era mantener vivas las historias y las esperanzas de mi gente, y eso es lo que ofrezco aquí: relatos, liderazgo y unión. No traigo fuerza ni materiales, pero la moral que genero puede marcar la diferencia entre seguir luchando o caer en la desesperanza. Mi cuerpo es frágil y no puedo acompañar expediciones largas, pero siempre estaré aquí para sostener el espíritu del refugio.",
            food: 0, water: 0, morale: 5, materials: 0, strenght: 0
        ),

        new NPCStory(
            "Ricardo",
            "Me llamo Ricardo y soy minero. He pasado años en minas contaminadas que dejaron mi cuerpo maltrecho, pero aún conservo la fuerza necesaria para el trabajo duro y la extracción de materiales. Necesito mucha comida y agua para mantenerme activo, pero si me das lo que necesito, puedo ser un motor para las expediciones y las labores pesadas. No soy muy expresivo ni sociable, pero cuando la supervivencia está en juego, los hechos hablan por mí.",
            food: -2, water: -1, morale: 0, materials: 4, strenght: 5
        ),

        new NPCStory(
            "Lorenzo",
            "Soy Lorenzo, cantante y animador. Mi voz ha sido un refugio para muchos en las noches más oscuras. Puedo levantar la moral y traer alegría cuando parece que ya no queda nada. Sin embargo, una vieja herida me impide hacer trabajos físicos y aportar en comida o materiales. Aun así, muchos dicen que mi canto mantiene vivos los corazones y eso no es poco en estos tiempos.",
            food: -1, water: -1, morale: 5, materials: 0, strenght: 0
        ),

        new NPCStory(
            "Tomás",
            "Me llamo Tomás y vengo del bosque, donde cazaba y recolectaba para sobrevivir. Cuando todo se vino abajo, mis habilidades me salvaron la vida y ahora traigo conmigo recursos y fuerza para las expediciones. Soy reservado y no siempre me adapto bien a la convivencia en grupo, mi silencio y distancia a veces causan conflictos. Pero si me necesitas para una misión, soy de los mejores para traer lo que hace falta.",
            food: 2, water: 1, morale: -2, materials: 3, strenght: 4
        ),
        new NPCStory(
            "Simón",
            "Por favor, necesito un lugar donde quedarme. No tengo mucho para ofrecer, sólo unas pocas latas de comida y algo de agua. La soledad me ha hecho perder fuerzas, pero estoy dispuesto a ayudar en lo que pueda. Sé que no soy un gran aporte, pero por favor, déjeme entrar. No quiero morir afuera solo.",
            food: -1, water: -1, morale: 1, materials: 0, strenght: 0
        ),
        new NPCStory(
            "Ramón",
            "Me llamo Ramón. Vengo huyendo de la nada, sin nada que dar. Solo busco un techo y algo de comida. Estoy cansado, y mi cuerpo ya no da para mucho. Si me dejan entrar, prometo no ser una carga, aunque sé que apenas podré aportar algo útil.",
            food: -1, water: 1, morale: 0, materials: 1, strenght: 0
        ),
        new NPCStory(
            "Dimitri",
            "Me llaman Dimitri, y no estoy aquí para hacer amigos. Soy un ladrón y un oportunista. Puedo conseguir comida y materiales, pero a través de métodos poco morales. Mi presencia solo genera desconfianza y peleas. Si me aceptan, será bajo mis términos, no los suyos.",
            food: 1, water: 1, morale: -4, materials: 4, strenght: 3
        ),
        new NPCStory(
            "Viktor",
            "Me llamo Viktor. He aprendido a ser autosuficiente en estos tiempos difíciles, y siempre consigo lo que necesito para sobrevivir. Puedo aportar materiales valiosos y fuerza para las expediciones. Soy directo y no suelo andar con rodeos, prefiero la acción a las palabras, y eso a veces puede causar diferencias con otros. Pero cuando se trata de proteger el refugio, soy alguien en quien se puede confiar.",
            food: -4, water: -5, morale: -6, materials: 1, strenght: 5
        ),
        new NPCStory(
            "Esteban",
            "Soy Esteban. Vengo con la intención de aportar y encontrar un lugar seguro. Traigo algunos recursos conmigo y me esfuerzo por integrarme al grupo. A veces puedo parecer reservado o un poco distante, pero es solo porque he pasado por mucho y aún trato de encontrar mi lugar aquí. Estoy dispuesto a ayudar en lo que sea necesario, aunque reconozco que a veces mis acciones no siempre agradan a todos.",
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
