# Structural Patterns (Lab 3)

## Pattern: Adapter

### Purpose:
Allows using `FileWriter` as a logger by adapting it to the `ILogger` interface. This pattern provides a way to convert one interface into another, allowing classes with incompatible interfaces to work together.

### Structure:
- **ILogger.cs** — Interface that defines logging methods: `Log()`, `Error()`, and `Warn()`. It serves as the target interface that all loggers must implement.
- **Logger.cs** — A concrete logger that outputs messages to the console with colors.
- **FileWriter.cs** — A class that writes text messages to a file.
- **FileLoggerAdapter.cs** — The adapter that allows `FileWriter` to be used as an `ILogger` implementation, enabling it to integrate with systems expecting `ILogger`.


---

## Pattern: Decorator

### Purpose:
Dynamically adds new properties (description and stats) to hero objects using decorators. This allows you to extend the functionality of objects without altering their structure, providing flexibility to add features at runtime.

### Structure (single file):
- **IHero** — Interface with methods `GetDescription()` and `GetStats()`, which must be implemented by hero classes.
- **Hero classes**:
  - `Warrior`, `Mage`, `Palladin` — These classes implement the `IHero` interface and provide base descriptions and stats for each hero.
- **Decorators (items)**:
  - `Armor`, `Artifact`, `Weapon` — These are decorator classes that extend the `HeroDecorator` class and add new properties to heroes (e.g., boosting stats or modifying the description).
- **HeroDecorator** — An abstract base class for decorators that implements the `IHero` interface and holds a reference to the hero object.
- **Main()** — Demonstrates how heroes can be decorated with multiple items at runtime to enhance their properties dynamically.
---

## Pattern: Bridge

### Purpose:
Separates abstraction (shapes) from implementation (rendering) to allow independent variation.

### Structure (single file):
- `IRenderer` — rendering interface with a method `Render(string shapeName)`
- **Implementations:**
  - `VectorRenderer` — renders shape as lines
  - `RasterRenderer` — renders shape as pixels
- `Shape` — abstract class representing the shape abstraction; depends on `IRenderer`
- **Shapes:**
  - `Circle`, `Square`, `Triangle` — concrete shapes that delegate rendering to the provided `IRenderer`
- `Main()` — demonstrates how different renderers can be used with different shapes independently
---

## Pattern: Proxy

### Purpose:
Controls access to text files and provides logging functionality, while delegating the actual file reading to `SmartTextReader`.

### Structure (single file):
- `ITextReader` — interface defining the method `ReadTextFile(string filePath)`
- `SmartTextReader` — basic file reader that reads text files and returns the content as a list of characters
- `SmartTextChecker` — proxy that adds logging functionality to `SmartTextReader`
- `SmartTextReaderLocker` — proxy that restricts file access based on a regex pattern (e.g., denies access to specific files like `secret.txt`)
- `Main()` — demonstrates how proxies control access to the files and how logging is handled

---

## Pattern: Composite

### Purpose:
Builds an HTML tree from nodes, allowing hierarchical relationships between text and element nodes.

### Structure:
- `LightNode.cs` — An abstract class that defines the basic behavior for nodes in LightHTML, with properties for `OuterHTML`.
- `LightTextNode.cs` — Represents a text node that contains only text and cannot have child elements, with its own `OuterHTML` implementation.
- `LightElementNode.cs` — A composite node that can contain other `LightNode` objects (children). It has attributes like `TagName`, `CssClasses`, `Display`, and `Closing` type. It also handles the construction of both `InnerHTML` and `OuterHTML`.
- `DisplayType` — Enum defining the display behavior of elements (`Block` or `Inline`).
- `ClosingType` — Enum defining if an element uses a single or paired closing tag.
- `Program` — Demonstrates how to build a tree structure of elements (`ul` with `li` elements), and prints both `InnerHTML` and `OuterHTML`.

---

## Pattern: Flyweight

### Purpose:
Optimizes memory usage by sharing common properties among objects, especially when many objects are of the same type but have different states. In this case, the goal is to minimize memory consumption by reusing HTML elements with the same tag name.

### Structure:
- `HtmlElementFactory.cs` — Factory class responsible for managing and providing shared `HtmlElementFlyweight` instances.
- `HtmlElementFlyweight.cs` — Represents a flyweight object that stores common properties (tag) and provides the `Render` method to generate HTML.
- `LightHTMLParser.cs` — Parses lines of text into HTML elements, reusing `HtmlElementFlyweight` instances via the `HtmlElementFactory`.
- `MemoryMonitor.cs` — Provides functionality to monitor memory usage before and after generating HTML.
- `MemorySizeConvertor.cs` — Converts memory size into human-readable formats (optional, not shown in the provided code but can be part of memory monitoring).
- `Main.cs` — Main entry point that demonstrates how memory is optimized using flyweights while parsing a large text (book) into HTML.
---
