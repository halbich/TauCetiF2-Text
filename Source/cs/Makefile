export TEXINPUTS=../tex//:

all: prace.pdf

opt: 
	gs -sDEVICE=pdfwrite -dCompatibilityLevel=1.4 -dPDFSETTINGS=/ebook -dNOPAUSE -dQUIET -dBATCH -sOutputFile=../output/Bakalarka_s.pdf ../output/Bakalarka.pdf
	rm -f ../output/Bakalarka.pdf

# LaTeX je potreba spustit nekolikrat, aby spravne spocital odkazy
prace.pdf: prace.tex $(wildcard *.tex) literatura.bib prace.xmpdata
	/usr/local/texlive/2016/bin/x86_64-linux/pdflatex $<
	/usr/local/texlive/2016/bin/x86_64-linux/bibtex prace
	#makeglossaries prace
	/usr/local/texlive/2016/bin/x86_64-linux/pdflatex $<
	/usr/local/texlive/2016/bin/x86_64-linux/pdflatex $<
	mv prace.pdf ../output/Bakalarka.pdf

clean:
	rm -f prace.pdf
	rm -rf *.log *.dvi *.toc *.lof *.lot *.out *.bbl *.blg *.xmpi *.acn *.alg *.glg *.glo *.gls *.ist *.acr *.xdy
	find -name '*.aux' | xargs rm
		
bib:
	/usr/local/texlive/2016/bin/x86_64-linux/bibtex prace	
	
