<article class="markdown-body entry-content" itemprop="mainContentOfPage"><h1><a id="user-content-creational-design-patterns" class="anchor" href="#creational-design-patterns" aria-hidden="true"><span class="octicon octicon-link"></span></a>Creational Design Patterns</h1>

<h2><a id="user-content-singleton" class="anchor" href="#singleton" aria-hidden="true"><span class="octicon octicon-link"></span></a>Singleton</h2>

<p>Singleton Design Pattern ограничава инстанциирането на съответния клас до един единствен обект. Това е полезно в случаите, когато е необходим само един обект, който да координира действията в цялата система.</p>

<ul>
<li><p><strong>Приложимост:</strong></p>

<ul>
<li>Използва се за глобални и единствени компоненти на приложението. </li>
</ul></li>
<li><p><strong>Предназначение:</strong></p> 

<ul>
<li>Осигурява създаването на единствена за класа инстанция с глобален достъп до нея</li>
</ul></li>
<li><p><strong>Конкретни приложения:</strong></p>

<ul>
<li>Abstract Factory, Builder и Prototype patterns могат да използват Singleton.</li>
<li>Обектите на Facade често са singleton-и, тъй като се изисква само един Facade Pattern обект.</li>
<li>State - обектите често са singleton-и</li>
<li>window manager, file system, logger</li>
</ul></li>

<li><p><strong>Имплементация</strong></p>

<div class="highlight highlight-c#"><pre><span class="pl-k">public</span> <span class="pl-k">sealed</span> <span class="pl-k">class</span> <span class="pl-en">Singleton</span>
{
    <span class="pl-k">private</span> <span class="pl-k">static</span> Singleton instance = <span class="pl-c1">null</span>;

    <span class="pl-k">private</span> <span class="pl-en">Singleton</span>()
    {
    }

    <span class="pl-k">public</span> <span class="pl-k">static</span> Singleton Instance
    {
        <span class="pl-k">get</span>
        {
            <span class="pl-k">if</span> (instance==<span class="pl-c1">null</span>)
            {
                instance = <span class="pl-k">new</span> Singleton();
            }
            <span class="pl-k">return</span> instance;
        }
    }
}</pre></div>

<p><img src="/Ange-Git/blob/master/MyTelerikAcademyHomeWorks/HighQualityCode/HW18.Creational-Patterns/images/Singleton.jpg" alt="Singleton" title="Singleton - UML diagram" style="max-width:100%;"></p>

</article>
