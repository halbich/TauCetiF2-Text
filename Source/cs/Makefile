export TEXINPUTS=../tex//:

all: prace.pdf


# LaTeX je potreba spustit nekolikrat, aby spravne spocital odkazy
prace.pdf: prace.tex $(wildcard *.tex) literatura.bib prace.xmpdata
	/usr/local/texlive/2016/bin/x86_64-linux/pdflatex $<
	/usr/local/texlive/2016/bin/x86_64-linux/bibtex prace
	/usr/local/texlive/2016/bin/x86_64-linux/pdflatex $<
	/usr/local/texlive/2016/bin/x86_64-linux/pdflatex $<
	cp -T prace.pdf ../output/Bakalarka.pdf

clean:
	rm -f *.log *.dvi *.aux *.toc *.lof *.lot *.out *.bbl *.blg *.xmpi
	rm -f prace.pdf
