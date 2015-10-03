<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:students="urn:students">
    <xsl:template match="/">
  <html>
      <body>
        <h1>Telerik Academy Students</h1>
        <table bgcolor="#E0E0E0" cellspacing="5" cellpading="50">
          <tr bgcolor="#EEEEEE">
            <th width="25px">Name</th>
            <th>Gender</th>
            <th>Birth Date</th>
            <th>Faculty No</th>
            <th>Specialty</th>
            <th>Course</th>
          </tr>
          <xsl:for-each select="students:students/students:student">
            <tr bgcolor="white">
              <td>
                <xsl:value-of select="students:name"/>
              </td>
              <td>
                <xsl:value-of select="students:sex"/>
              </td>
              <td>
                <xsl:value-of select="students:birthDate"/>
              </td>
              <td>
                <xsl:value-of select="students:facultyNumber"/>
              </td>
              <td>
                <xsl:value-of select="students:specialty"/>
              </td>
              <td>
                <xsl:value-of select="students:course"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>